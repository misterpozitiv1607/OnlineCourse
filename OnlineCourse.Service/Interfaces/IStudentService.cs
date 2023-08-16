using OnlineCourse.Service.Dtos.Students;

namespace OnlineCourse.Service.Interfaces;

public interface IStudentService
{
    Task<StudentResultDto> AddAsync(StudentCreationDto dto);
    Task<StudentResultDto> ModifyAsync(StudentUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<StudentResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<StudentResultDto>> RetrieveAllAsync();
}
