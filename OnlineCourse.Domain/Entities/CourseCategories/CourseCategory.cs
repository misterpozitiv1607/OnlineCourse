using OnlineCourse.Domain.Commons;
using OnlineCourse.Domain.Entities.Courses;

namespace OnlineCourse.Domain.Entities.CourseCategories;

public class CourseCategory:Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }
    public Course Course { get; set; }
}
