using AutoMapper;
using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Service.Dtos.Courses;
using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Dtos.Teachers;
using OnlineCourse.Domain.Entities.Orders;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Domain.Entities.Teachers;
using OnlineCourse.Service.Dtos.CourseCategories;
using OnlineCourse.Domain.Entities.CourseCategories;




namespace OnlineCourse.Service.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        // Course
        CreateMap<Course,CourseCreationDto>().ReverseMap();
        CreateMap<Course, CourseUpdateDto>().ReverseMap();
        CreateMap<Course, CourseResultDto>().ReverseMap();

        // CourseCategory
        CreateMap<CourseCategory, CourseCategoryCreationDto>().ReverseMap();
        CreateMap<CourseCategory, CourseCategoryUpdateDto>().ReverseMap();
        CreateMap<CourseCategory, CourseCategoryResultDto>().ReverseMap();

        // Teacher
        CreateMap<Teacher, TeacherCreationDto>().ReverseMap();
        CreateMap<Teacher, TeacherUpdateDto>().ReverseMap();
        CreateMap<Teacher, TeacherResultDto>().ReverseMap();

        // Student
        CreateMap<Student, StudentCreationDto>().ReverseMap();
        CreateMap<Student, StudentUpdateDto>().ReverseMap();
        CreateMap<Student, StudentResultDto>().ReverseMap();

        // Order
        CreateMap<Order, OrderCreationDto>().ReverseMap();
        CreateMap<Order, OrderUpdateDto>().ReverseMap();
        CreateMap<Order, OrderResultDto>().ReverseMap();
    }
}
