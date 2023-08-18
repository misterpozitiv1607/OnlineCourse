using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.Repositories;
using OnlineCourse.Domain.Entities.CourseCategories;
using OnlineCourse.Service.Dtos.CourseCategories;
using OnlineCourse.Service.Interfaces;
using OnlineCourse.Service.Mappers;

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

    public async Task<CourseCategoryResultDto> AddAsync(CourseCategoryCreationDto dto)
    {
        CourseCategory coursecategory = mapper.Map<CourseCategory>(dto);
        var existCourseCategory = unitOfWork.CourseCategoryRepository.SelectAll().FirstOrDefault(u => u.Name.Equals(dto.Name));

        if (existCourseCategory is not null)
            return null;
        await this.unitOfWork.CourseCategoryRepository.CreateAsync(coursecategory);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<CourseCategoryResultDto>(coursecategory);
        return result;
    }

    public async Task<CourseCategoryResultDto> ModifyAsync(CourseCategoryUpdateDto dto)
    {
        CourseCategory existCourseCategory = await this.unitOfWork.CourseCategoryRepository.SelectById(dto.Id);
        if (existCourseCategory is null)
            return null;

        var mappedCourseCategory = this.mapper.Map(dto, existCourseCategory);
        this.unitOfWork.CourseCategoryRepository.Update(mappedCourseCategory);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<CourseCategoryResultDto>(mappedCourseCategory);

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        CourseCategory existCourseCategory = await this.unitOfWork.CourseCategoryRepository.SelectById(id);

        if (existCourseCategory is null)
            return false;
        this.unitOfWork.CourseCategoryRepository.Delete(existCourseCategory);
        this.unitOfWork.SaveAsync();

        return true;
    }

    public async Task<CourseCategoryResultDto> RetrieveByIdAsync(long id)
    {
        CourseCategory existCourseCategory = await this.unitOfWork.CourseCategoryRepository.SelectById(id);
        if (existCourseCategory is null)
            return null;

        var result = this.mapper.Map<CourseCategoryResultDto>(existCourseCategory);

        return result;
    }

    public async Task<IEnumerable<CourseCategoryResultDto>> RetrieveAllAsync()
    {
        var coursecategorys = await this.unitOfWork.CourseCategoryRepository.SelectAll().ToListAsync();


        foreach (var item in coursecategorys)
        {
            CourseCategory coursecategory = await this.unitOfWork.CourseCategoryRepository.SelectById(item.Id);
        }

        var result = this.mapper.Map<IEnumerable<CourseCategoryResultDto>>(coursecategorys);
        return result;
    }
}
