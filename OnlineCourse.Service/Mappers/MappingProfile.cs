using AutoMapper;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Service.Dtos.CourseCategories;
using OnlineCourse.Service.Dtos.Courses;

namespace OnlineCourse.Service.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        //Course
        CreateMap<Course,CourseCreationDto>().ReverseMap();
        CreateMap<Course, CourseUpdateDto>().ReverseMap();
        CreateMap<Course, CourseResultDto>().ReverseMap();

        //Course
        CreateMap<Course, CourseCreationDto>().ReverseMap();
        CreateMap<Course, CourseUpdateDto>().ReverseMap();
        CreateMap<Course, CourseResultDto>().ReverseMap();

        //Course
        CreateMap<Course, CourseCreationDto>().ReverseMap();
        CreateMap<Course, CourseUpdateDto>().ReverseMap();
        CreateMap<Course, CourseResultDto>().ReverseMap();

        //Course
        CreateMap<Course, CourseCreationDto>().ReverseMap();
        CreateMap<Course, CourseUpdateDto>().ReverseMap();
        CreateMap<Course, CourseResultDto>().ReverseMap();


    }
}
