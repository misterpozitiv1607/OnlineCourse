using OnlineCourse.Service.Dtos.CourseCategories;

namespace OnlineCourse.Service.Interfaces;

public interface ICourseCategoryService
{
    Task<CourseCategoryResultDto> AddAsync(CourseCategoryCreationDto dto);
    Task<CourseCategoryResultDto> ModifyAsync(CourseCategoryUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<CourseCategoryResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CourseCategoryResultDto>> RetrieveAllAsync();
}
