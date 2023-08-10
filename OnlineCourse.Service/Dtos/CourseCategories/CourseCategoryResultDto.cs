using OnlineCourse.Service.Dtos.Courses;

namespace OnlineCourse.Service.Dtos.CourseCategories;

public class CourseCategoryResultDto
{
    public long id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CourseResultDto CourseResultDto { get; set; }
}