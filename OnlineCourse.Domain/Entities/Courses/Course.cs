using OnlineCourse.Domain.Commons;
using OnlineCourse.Domain.Entities.Orders;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Domain.Entities.Teachers;

namespace OnlineCourse.Domain.Entities.Courses;

public class Course:Auditable
{
    public double Price { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }

    public long StudentId { get; set; }
    public Student Student { get; set; }

    public long TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public long OrderId { get; set; }
    public Order Order { get; set; }
}
