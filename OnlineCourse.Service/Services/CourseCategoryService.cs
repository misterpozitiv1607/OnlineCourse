using AutoMapper;
using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Mappers;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.Repositories;
using OnlineCourse.Service.Interfaces;
using OnlineCourse.Service.Dtos.CourseCategories;
using OnlineCourse.Domain.Entities.CourseCategories;

namespace OnlineCourse.Service.Services;

public class CourseCategoryService : ICourseCategoryService
{
    private readonly Mapper mapper;
    private readonly UnitOfWork unitOfWork;

    public CourseCategoryService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));

    }

    public async Task<Response<CourseCategoryResultDto>> CreateAsync(CourseCategoryCreationDto dto)
    {
        CourseCategory coursecategory = mapper.Map<CourseCategory>(dto);
        var existCourseCategory = unitOfWork.CourseCategoryRepository.SelectAll().FirstOrDefault(u => u.Name.Equals(dto.Name));

        if (existCourseCategory is not null)
            return new Response<CourseCategoryResultDto>
            {
                StatusCode = 403,
                Message = $"This coursecategory allready exist Name:{existCourseCategory.Name}"
            };

        await this.unitOfWork.CourseCategoryRepository.CreateAsync(coursecategory);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<CourseCategoryResultDto>(coursecategory);
        return new Response<CourseCategoryResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<CourseCategoryResultDto>> UpdateAsync(CourseCategoryUpdateDto dto)
    {
        CourseCategory existCourseCategory = await this.unitOfWork.CourseCategoryRepository.SelectById(dto.Id);
        if (existCourseCategory is null)
            return new Response<CourseCategoryResultDto>
            {
                StatusCode = 403,
                Message = $"This course is not found Id:{existCourseCategory.Id}",
                Data = null
            };

        var mappedCourseCategory = this.mapper.Map(dto, existCourseCategory);
        this.unitOfWork.CourseCategoryRepository.Update(mappedCourseCategory);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<CourseCategoryResultDto>(mappedCourseCategory);

        return new Response<CourseCategoryResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        CourseCategory existCourseCategory = await this.unitOfWork.CourseCategoryRepository.SelectById(id);

        if (existCourseCategory is null)
            return new Response<bool>
            {
                StatusCode = 403,
                Message = $"This coursecategory is not found Id:{existCourseCategory.Id}",
                Data = false
            };
        this.unitOfWork.CourseCategoryRepository.Delete(existCourseCategory);
        this.unitOfWork.SaveAsync();

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<CourseCategoryResultDto>> GetByIdAsync(long id)
    {
        CourseCategory existCourseCategory = await this.unitOfWork.CourseCategoryRepository.SelectById(id);
        if (existCourseCategory is null)
            return new Response<CourseCategoryResultDto>
            {
                StatusCode = 403,
                Message = $"This coursecategory is not found Id:{existCourseCategory.Id}",
                Data = null
            };

        var result = this.mapper.Map<CourseCategoryResultDto>(existCourseCategory);

        return new Response<CourseCategoryResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<IEnumerable<CourseCategoryResultDto>>> GetAllAsync()
    {
        var coursecategorys = await this.unitOfWork.CourseCategoryRepository.SelectAll().ToListAsync();


        foreach (var item in coursecategorys)
        {
            CourseCategory coursecategory = await this.unitOfWork.CourseCategoryRepository.SelectById(item.Id);
        }

        var result = this.mapper.Map<IEnumerable<CourseCategoryResultDto>>(coursecategorys);
        return new Response<IEnumerable<CourseCategoryResultDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
