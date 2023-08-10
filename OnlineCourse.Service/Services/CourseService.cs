using AutoMapper;
using OnlineCourse.DAL.Repositories;
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

    public Task<Response<CourseResultDto>> CreateAsync(CourseCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<CourseResultDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<CourseResultDto>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<CourseResultDto>> UpdateAsync(CourseUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
