using OnlineCourse.Service.Dtos.Students;

namespace OnlineCourse.Service.Interfaces;

public interface IStudentService
{
    Task<StudentResultDto> CreateAsync(StudentCreationDto dto);
    Task<StudentResultDto> UpdateAsync(StudentUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<StudentResultDto> GetByIdAsync(long id);
    Task<IEnumerable<StudentResultDto>> GetAllAsync();
}
