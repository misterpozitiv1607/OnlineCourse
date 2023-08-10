using OnlineCourse.Service.Dtos.Courses;
using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Service.Helpers;

namespace OnlineCourse.Service.Interfaces;

public interface ICourseService
{
    Task<Response<CourseResultDto>> CreateAsync(CourseCreationDto dto);
    Task<Response<CourseResultDto>> UpdateAsync(CourseUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<CourseResultDto>> GetByIdAsync(long id);
    Task<Response<List<CourseResultDto>>> GetAllAsync();
}
