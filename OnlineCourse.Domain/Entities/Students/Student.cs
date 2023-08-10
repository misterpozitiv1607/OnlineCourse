using OnlineCourse.Domain.Commons;

namespace OnlineCourse.Domain.Entities.Students;

public class Student:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

}
