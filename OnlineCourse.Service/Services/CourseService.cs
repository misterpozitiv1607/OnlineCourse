using OnlineCourse.Service.Dtos.Courses;
using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Service.Services;

public class CourseService : ICourseService
{
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
