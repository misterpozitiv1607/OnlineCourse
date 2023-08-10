using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Dtos.Teachers;

namespace OnlineCourse.Service.Dtos.Courses;

public class CourseResultDto
{
    public long Id { get; set; }
    public double Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public StudentResultDto StudentResultDto { get; set; }
    public TeacherResultDto TeacherResultDto { get; set; }
    public OrderResultDto OrderResultDto { get; set; }
}
