using OnlineCourse.Service.Dtos.Teachers;
using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Service.Services;

public class TeacherService : ITeacherService
{
    public Task<Response<TeacherResultDto>> CreateAsync(TeacherCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<TeacherResultDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<TeacherResultDto>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<TeacherResultDto>> UpdateAsync(TeacherUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
