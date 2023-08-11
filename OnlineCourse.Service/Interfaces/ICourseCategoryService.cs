using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Dtos.CourseCategories;

namespace OnlineCourse.Service.Interfaces;

public interface ICourseCategoryService
{
    Task<Response<CourseCategoryResultDto>> CreateAsync(CourseCategoryCreationDto dto);
    Task<Response<CourseCategoryResultDto>> UpdateAsync(CourseCategoryUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<CourseCategoryResultDto>> GetByIdAsync(long id);
    Task<Response<IEnumerable<CourseCategoryResultDto>>> GetAllAsync();
}
