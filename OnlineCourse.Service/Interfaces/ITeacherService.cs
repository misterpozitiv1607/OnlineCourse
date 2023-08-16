using OnlineCourse.Service.Dtos.Teachers;

namespace OnlineCourse.Service.Interfaces;

public interface ITeacherService
{
    Task<TeacherResultDto> AddAsync(TeacherCreationDto dto);
    Task<TeacherResultDto> ModifyAsync(TeacherUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<TeacherResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<TeacherResultDto>> RetrieveAllAsync();
}
