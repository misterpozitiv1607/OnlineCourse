using OnlineCourse.Service.Dtos.CourseCategories;

namespace OnlineCourse.Service.Interfaces;

public interface ICourseCategoryService
{
    Task<CourseCategoryResultDto> CreateAsync(CourseCategoryCreationDto dto);
    Task<CourseCategoryResultDto> UpdateAsync(CourseCategoryUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<CourseCategoryResultDto> GetByIdAsync(long id);
    Task<IEnumerable<CourseCategoryResultDto>> GetAllAsync();
}
