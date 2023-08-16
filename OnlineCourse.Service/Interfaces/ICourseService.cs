using OnlineCourse.Service.Dtos.Courses;

namespace OnlineCourse.Service.Interfaces;

public interface ICourseService
{
    Task<CourseResultDto> AddAsync(CourseCreationDto dto);
    Task<CourseResultDto> ModifyAsync(CourseUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<CourseResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CourseResultDto>> RetrieveAllAsync();
}
