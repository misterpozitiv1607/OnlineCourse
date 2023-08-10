using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Service.Services;

public class StudentService : IStudentService
{
    public StudentService()
    {
        
    }

    public Task<Response<StudentResultDto>> CreateAsync(StudentCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<StudentResultDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<StudentResultDto>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<StudentResultDto>> UpdateAsync(StudentUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
