using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.Repositories;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Service.Dtos.Courses;
using OnlineCourse.Service.Interfaces;
using OnlineCourse.Service.Mappers;

namespace OnlineCourse.Service.Services;

public class CourseService : ICourseService
{
    private readonly Mapper mapper;
    private readonly UnitOfWork unitOfWork;

    public CourseService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));

    }

    public async Task<CourseResultDto> AddAsync(CourseCreationDto dto)
    {
        Course  course = mapper.Map<Course>(dto);
        var existCourse = unitOfWork.CourseRepository.SelectAll().FirstOrDefault(u => u.StartDate.Equals(dto.StartDate));

        if (existCourse is not null)
            return null;

        await this.unitOfWork.CourseRepository.CreateAsync(course);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<CourseResultDto>(course);
        return result;
    }

    public async Task<CourseResultDto> ModifyAsync(CourseUpdateDto dto)
    {
        Course existCourse = await this.unitOfWork.CourseRepository.SelectById(dto.Id);
        if (existCourse is null)
            return null;

        var mappedCourse = this.mapper.Map(dto, existCourse);
        this.unitOfWork.CourseRepository.Update(mappedCourse);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<CourseResultDto>(mappedCourse);

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Course existCourse = await this.unitOfWork.CourseRepository.SelectById(id);

        if (existCourse is null)
            return false;
        this.unitOfWork.CourseRepository.Delete(existCourse);
        this.unitOfWork.SaveAsync();

        return true;
    }

    public async Task<CourseResultDto> RetrieveByIdAsync(long id)
    {
        Course existCourse = await this.unitOfWork.CourseRepository.SelectById(id);
        if (existCourse is null)
            return null;

        var result = this.mapper.Map<CourseResultDto>(existCourse);

        return result;
    }

    public async Task<IEnumerable<CourseResultDto>> RetrieveAllAsync()
    {
        var courses = await this.unitOfWork.CourseRepository.SelectAll().ToListAsync();


        foreach (var item in courses)
        {
            Course course = await this.unitOfWork.CourseRepository.SelectById(item.Id);
        }

        var result = this.mapper.Map<IEnumerable<CourseResultDto>>(courses);
        return result;
    }
}
