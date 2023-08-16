using OnlineCourse.Service.Dtos.Teachers;

namespace OnlineCourse.Service.Interfaces;

public interface ITeacherService
{
    Task<TeacherResultDto> CreateAsync(TeacherCreationDto dto);
    Task<TeacherResultDto> UpdateAsync(TeacherUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<TeacherResultDto> GetByIdAsync(long id);
    Task<IEnumerable<TeacherResultDto>> GetAllAsync();
}
