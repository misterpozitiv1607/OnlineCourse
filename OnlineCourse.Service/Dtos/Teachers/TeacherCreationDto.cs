namespace OnlineCourse.Service.Dtos.Teachers;

public class TeacherCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Speciality { get; set; }
    public string Email { get; set; }
    public int Experince { get; set; }
}
