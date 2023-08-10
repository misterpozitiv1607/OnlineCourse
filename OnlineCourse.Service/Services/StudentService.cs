using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.Repositories;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Interfaces;
using OnlineCourse.Service.Mappers;

namespace OnlineCourse.Service.Services;

public class StudentService : IStudentService
{
    private readonly Mapper mapper;
    private readonly UnitOfWork unitOfWork;

    public StudentService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));

    }

    public async Task<Response<StudentResultDto>> CreateAsync(StudentCreationDto dto)
    {
        Student student = mapper.Map<Student>(dto);
        var existStudent = unitOfWork.StudentRepository.SelectAll().FirstOrDefault(u => u.Phone.Equals(dto.Phone));

        if (existStudent is not null)
            return new Response<StudentResultDto>
            {
                StatusCode = 403,
                Message = $"This student is not found Phone:{existStudent.Phone}"
            };

        await this.unitOfWork.StudentRepository.CreateAsync(student);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<StudentResultDto>(student);
        return new Response<StudentResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<StudentResultDto>> UpdateAsync(StudentUpdateDto dto)
    {
        Student existStudent = await this.unitOfWork.StudentRepository.SelectById(dto.Id);
        if (existStudent is null)
            return new Response<StudentResultDto>
            {
                StatusCode = 403,
                Message = $"This student is not found Id:{existStudent.Id}",
                Data = null
            };

        var mappedStudent = this.mapper.Map(dto, existStudent);
        this.unitOfWork.StudentRepository.Update(mappedStudent);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<StudentResultDto>(mappedStudent);

        return new Response<StudentResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };

    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        Student existStudent = await this.unitOfWork.StudentRepository.SelectById(id);

        if (existStudent is null)
            return new Response<bool>
            {
                StatusCode = 403,
                Message = $"This student is not found Id:{existStudent.Id}",
                Data = false
            };
        this.unitOfWork.StudentRepository.Delete(existStudent);
        this.unitOfWork.SaveAsync();

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<StudentResultDto>> GetByIdAsync(long id)
    {
        Student existStudent = await this.unitOfWork.StudentRepository.SelectById(id);
        if (existStudent is null)
            return new Response<StudentResultDto>
            {
                StatusCode = 403,
                Message = $"This student is not found Id:{existStudent.Id}",
                Data = null
            };

        var result = this.mapper.Map<StudentResultDto>(existStudent);

        return new Response<StudentResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<IEnumerable<StudentResultDto>>> GetAllAsync()
    {
        var students = await this.unitOfWork.StudentRepository.SelectAll().ToListAsync();


        foreach (var item in students)
        {
            Student student = await this.unitOfWork.StudentRepository.SelectById(item.Id);
        }

        var result = this.mapper.Map<IEnumerable<StudentResultDto>>(students);
        return new Response<IEnumerable<StudentResultDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
