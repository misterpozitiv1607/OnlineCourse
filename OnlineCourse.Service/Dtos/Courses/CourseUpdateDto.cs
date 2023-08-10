namespace OnlineCourse.Service.Dtos.Courses;

public class CourseUpdateDto
{
    public long Id { get; set; }
    public double Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public long StudentId { get; set; }
    public long TeacherId { get; set; }
    public long OrderId { get; set; }
}
