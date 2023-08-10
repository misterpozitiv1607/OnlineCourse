namespace OnlineCourse.Service.Dtos.CourseCategories;

public class CourseCategoryUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
}
