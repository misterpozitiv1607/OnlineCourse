using AutoMapper;
using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Mappers;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.Repositories;
using OnlineCourse.Service.Interfaces;
using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Domain.Entities.Students;

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

    public async Task<StudentResultDto> AddAsync(StudentCreationDto dto)
    {
        Student student = mapper.Map<Student>(dto);
        var existStudent = unitOfWork.StudentRepository.SelectAll().FirstOrDefault(u => u.Phone.Equals(dto.Phone));

        if (existStudent is not null)
            return null;

        await this.unitOfWork.StudentRepository.CreateAsync(student);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<StudentResultDto>(student);
        return result;
    }

    public async Task<StudentResultDto> ModifyAsync(StudentUpdateDto dto)
    {
        Student existStudent = await this.unitOfWork.StudentRepository.SelectById(dto.Id);
        if (existStudent is null)
            return null;

        var mappedStudent = this.mapper.Map(dto, existStudent);
        this.unitOfWork.StudentRepository.Update(mappedStudent);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<StudentResultDto>(mappedStudent);
        Console.WriteLine(result.FirstName);

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Student existStudent = await this.unitOfWork.StudentRepository.SelectById(id);

        if (existStudent is null)
            return false;
        this.unitOfWork.StudentRepository.Delete(existStudent);
        this.unitOfWork.SaveAsync();

        return true;
    }

    public async Task<StudentResultDto> RetrieveByIdAsync(long id)
    {
        Student existStudent = await this.unitOfWork.StudentRepository.SelectById(id);
        if (existStudent is null)
            return null;

        var result = this.mapper.Map<StudentResultDto>(existStudent);

        return result;
    }

    public async Task<IEnumerable<StudentResultDto>> RetrieveAllAsync()
    {
        var students = await this.unitOfWork.StudentRepository.SelectAll().ToListAsync();


        foreach (var item in students)
        {
            Student student = await this.unitOfWork.StudentRepository.SelectById(item.Id);
        }

        var result = this.mapper.Map<IEnumerable<StudentResultDto>>(students);
        return result;
    }
}
