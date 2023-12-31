﻿using OnlineCourse.Domain.Enums;
using OnlineCourse.Service.Dtos.Students;

namespace OnlineCourse.Service.Dtos.Teachers;

public class TeacherResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public TeacherLevel TeacherLevel { get; set; }
    public string Speciality { get; set; }
    public string Email { get; set; }
    public int Experince { get; set; }
}