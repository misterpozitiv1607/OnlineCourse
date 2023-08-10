using OnlineCourse.Domain.Entities.Students;

namespace OnlineCourse.Service.Dtos.Students;

public class StudentResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
