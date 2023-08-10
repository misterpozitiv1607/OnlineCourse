using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Dtos.Teachers;
using OnlineCourse.Service.Helpers;

namespace OnlineCourse.Service.Interfaces;

public interface IStudentService
{
    Task<Response<StudentResultDto>> CreateAsync(StudentCreationDto dto);
    Task<Response<StudentResultDto>> UpdateAsync(StudentUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<StudentResultDto>> GetByIdAsync(long id);
    Task<Response<List<StudentResultDto>>> GetAllAsync();
}
