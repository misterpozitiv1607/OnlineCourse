using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.Repositories;
using OnlineCourse.Domain.Entities.Teachers;
using OnlineCourse.Service.Dtos.Teachers;
using OnlineCourse.Service.Interfaces;
using OnlineCourse.Service.Mappers;

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
    public async Task<TeacherResultDto> AddAsync(TeacherCreationDto dto)
    {
        Teacher teacher = mapper.Map<Teacher>(dto);
        var existTeacher = unitOfWork.TeacherRepository.SelectAll().FirstOrDefault(u => u.Phone.Equals(dto.Phone));

        if (existTeacher is not null)
            return null;

        await this.unitOfWork.TeacherRepository.CreateAsync(teacher);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<TeacherResultDto>(teacher);
        return result;
    }

    public async Task<TeacherResultDto> ModifyAsync(TeacherUpdateDto dto)
    {
        Teacher existTeacher = await this.unitOfWork.TeacherRepository.SelectById(dto.Id);
        if (existTeacher is null)
            return null;

        var mappedTeacher = this.mapper.Map(dto, existTeacher);
        this.unitOfWork.TeacherRepository.Update(existTeacher);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<TeacherResultDto>(mappedTeacher);

        return result;

    }

    public async Task<bool> RemoveAsync(long id)
    {
        Teacher existTeacher =await this.unitOfWork.TeacherRepository.SelectById(id);

        if (existTeacher is null)
            return false;
        this.unitOfWork.TeacherRepository.Delete(existTeacher);

        await this.unitOfWork.SaveAsync();

        return true;
    }

    public async Task<TeacherResultDto> RetrieveByIdAsync(long id)
    {
        var existTeacher = await this.unitOfWork.TeacherRepository.SelectById(id);
        if (existTeacher is null)
            return null;

        var result = this.mapper.Map<TeacherResultDto>(existTeacher);
        this.unitOfWork.SaveAsync();

        return result;
    }

    public async Task<IEnumerable<TeacherResultDto>> RetrieveAllAsync()
    {
        var teachers = await this.unitOfWork.TeacherRepository.SelectAll().ToListAsync();


        foreach (var item in teachers)
        {
            Teacher teacher = await this.unitOfWork.TeacherRepository.SelectById(item.Id);
        }

        var result = this.mapper.Map<IEnumerable<TeacherResultDto>>(teachers);
        return result;
    }
}
