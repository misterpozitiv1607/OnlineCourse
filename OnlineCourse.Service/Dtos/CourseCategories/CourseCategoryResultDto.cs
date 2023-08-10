namespace OnlineCourse.Service.Dtos.CourseCategories;

public class CourseCategoryResultDto
{
    public long id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
}