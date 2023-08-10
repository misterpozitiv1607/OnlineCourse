using OnlineCourse.Domain.Commons;
using OnlineCourse.Domain.Enums;

namespace OnlineCourse.Domain.Entities.Teachers;
public class Teacher:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Speciality { get; set; }
    public TeacherLevel TeacherLevel { get; set; }
    public string Email { get; set; }
    public int Experince { get; set; }
}

