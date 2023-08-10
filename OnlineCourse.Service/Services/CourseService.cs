using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.Repositories;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Service.Dtos.Courses;
using OnlineCourse.Service.Helpers;
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

    public async Task<Response<CourseResultDto>> CreateAsync(CourseCreationDto dto)
    {
        Course  course = mapper.Map<Course>(dto);
        var existCourse = unitOfWork.CourseRepository.SelectAll().FirstOrDefault(u => u.StartDate.Equals(dto.StartDate));

        if (existCourse is not null)
            return new Response<CourseResultDto>
            {
                StatusCode = 403,
                Message = $"This course allready exist PaymentCode:{existCourse.StartDate}"
            };

        await this.unitOfWork.CourseRepository.CreateAsync(course);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<CourseResultDto>(course);
        return new Response<CourseResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<CourseResultDto>> UpdateAsync(CourseUpdateDto dto)
    {
        Course existCourse = await this.unitOfWork.CourseRepository.SelectById(dto.Id);
        if (existCourse is null)
            return new Response<CourseResultDto>
            {
                StatusCode = 403,
                Message = $"This course is not found Id:{existCourse.Id}",
                Data = null
            };

        var mappedCourse = this.mapper.Map(dto, existCourse);
        this.unitOfWork.CourseRepository.Update(mappedCourse);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<CourseResultDto>(mappedCourse);

        return new Response<CourseResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        Course existCourse = await this.unitOfWork.CourseRepository.SelectById(id);

        if (existCourse is null)
            return new Response<bool>
            {
                StatusCode = 403,
                Message = $"This course is not found Id:{existCourse.Id}",
                Data = false
            };
        this.unitOfWork.CourseRepository.Delete(existCourse);
        this.unitOfWork.SaveAsync();

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<CourseResultDto>> GetByIdAsync(long id)
    {
        Course existCourse = await this.unitOfWork.CourseRepository.SelectById(id);
        if (existCourse is null)
            return new Response<CourseResultDto>
            {
                StatusCode = 403,
                Message = $"This course is not found Id:{existCourse.Id}",
                Data = null
            };

        var result = this.mapper.Map<CourseResultDto>(existCourse);

        return new Response<CourseResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<IEnumerable<CourseResultDto>>> GetAllAsync()
    {
        var courses = await this.unitOfWork.CourseRepository.SelectAll().ToListAsync();


        foreach (var item in courses)
        {
            Course course = await this.unitOfWork.CourseRepository.SelectById(item.Id);
        }

        var result = this.mapper.Map<IEnumerable<CourseResultDto>>(courses);
        return new Response<IEnumerable<CourseResultDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
