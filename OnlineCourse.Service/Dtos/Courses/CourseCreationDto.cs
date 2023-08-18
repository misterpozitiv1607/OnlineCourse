using OnlineCourse.Domain.Entities.Orders;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Domain.Entities.Teachers;

namespace OnlineCourse.Service.Dtos.Courses;

public class CourseCreationDto
{

    public double Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public long StudentId { get; set; }
    public long TeacherId { get; set; }
    public long OrderId { get; set; }
}
