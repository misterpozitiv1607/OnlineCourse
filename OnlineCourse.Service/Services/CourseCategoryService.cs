using OnlineCourse.Service.Dtos.CourseCategories;
using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Service.Services;

public class CourseCategoryService : ICourseCategoryService
{
    public Task<Response<CourseCategoryResultDto>> CreateAsync(CourseCategoryCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<CourseCategoryResultDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<CourseCategoryResultDto>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<CourseCategoryResultDto>> UpdateAsync(CourseCategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
