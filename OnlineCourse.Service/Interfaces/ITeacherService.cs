using OnlineCourse.Service.Dtos.Teachers;
using OnlineCourse.Service.Helpers;

namespace OnlineCourse.Service.Interfaces;

public interface ITeacherService
{
    Task<Response<TeacherResultDto>> CreateAsync(TeacherCreationDto dto);
    Task<Response<TeacherResultDto>> UpdateAsync(TeacherUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<TeacherResultDto>> GetByIdAsync(long id);
    Task<Response<IEnumerable<TeacherResultDto>>> GetAllAsync();
}
