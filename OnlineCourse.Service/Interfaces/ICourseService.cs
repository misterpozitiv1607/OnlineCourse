using OnlineCourse.Service.Dtos.Courses;

namespace OnlineCourse.Service.Interfaces;

public interface ICourseService
{
    Task<CourseResultDto> CreateAsync(CourseCreationDto dto);
    Task<CourseResultDto> UpdateAsync(CourseUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<CourseResultDto> GetByIdAsync(long id);
    Task<IEnumerable<CourseResultDto>> GetAllAsync();
}
