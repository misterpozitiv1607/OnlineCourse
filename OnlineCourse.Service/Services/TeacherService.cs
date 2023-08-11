using AutoMapper;
using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Mappers;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.Repositories;
using OnlineCourse.Service.Interfaces;
using OnlineCourse.Service.Dtos.Teachers;
using OnlineCourse.Domain.Entities.Teachers;

namespace OnlineCourse.Service.Services;

public class TeacherService : ITeacherService
{
    private readonly Mapper mapper;
    private readonly UnitOfWork unitOfWork;

    public TeacherService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));

    }
    public async Task<Response<TeacherResultDto>> CreateAsync(TeacherCreationDto dto)
    {
        Teacher teacher = mapper.Map<Teacher>(dto);
        var existTeacher = unitOfWork.TeacherRepository.SelectAll().FirstOrDefault(u => u.Phone.Equals(dto.Phone));

        if (existTeacher is not null)
            return new Response<TeacherResultDto>
            {
                StatusCode = 403,
                Message = $"This teacher allready exist Phone:{existTeacher.Phone}"
            };

        await this.unitOfWork.TeacherRepository.CreateAsync(teacher);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<TeacherResultDto>(teacher);
        return new Response<TeacherResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<TeacherResultDto>> UpdateAsync(TeacherUpdateDto dto)
    {
        Teacher existTeacher = await this.unitOfWork.TeacherRepository.SelectById(dto.Id);
        if (existTeacher is null)
            return new Response<TeacherResultDto>
            {
                StatusCode = 403,
                Message = $"This teacher is not found",
                Data = null
            };

        var mappedTeacher = this.mapper.Map(dto, existTeacher);
        this.unitOfWork.TeacherRepository.Update(existTeacher);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<TeacherResultDto>(mappedTeacher);

        return new Response<TeacherResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };

    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        Teacher existTeacher =await this.unitOfWork.TeacherRepository.SelectById(id);

        if (existTeacher is null)
            return new Response<bool>
            {
                StatusCode = 403,
                Message = $"This teacher is not found",
                Data = false
            };
        this.unitOfWork.TeacherRepository.Delete(existTeacher);

        await this.unitOfWork.SaveAsync();

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<TeacherResultDto>> GetByIdAsync(long id)
    {
        var existTeacher = await this.unitOfWork.TeacherRepository.SelectById(id);
        if (existTeacher is null)
            return new Response<TeacherResultDto>
            {
                StatusCode = 403,
                Message = $"This teacher is not fount",
                Data = null
            };

        var result = this.mapper.Map<TeacherResultDto>(existTeacher);
        await this.unitOfWork.SaveAsync();

        return new Response<TeacherResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<IEnumerable<TeacherResultDto>>> GetAllAsync()
    {
        var teachers = await this.unitOfWork.TeacherRepository.SelectAll().ToListAsync();


        foreach (var item in teachers)
        {
            Teacher teacher = await this.unitOfWork.TeacherRepository.SelectById(item.Id);
        }

        var result = this.mapper.Map<IEnumerable<TeacherResultDto>>(teachers);
        return new Response<IEnumerable<TeacherResultDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
