using AutoMapper;
using OnlineCourse.DAL.IRepositories;
using OnlineCourse.Domain.Entities.CourseCategories;
using OnlineCourse.Service.Dtos.CourseCategories;
using OnlineCourse.Service.Exceptions;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Service.Services;

public class CourseCategoryService : ICourseCategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CourseCategoryResultDto> AddAsync(CourseCategoryCreationDto dto)
    {
        CourseCategory existCourseCategory = await _unitOfWork.CourseCategoryRepository.SelectAsync(e => e.Name == dto.Name && e.CourseId == dto.CourseId && e.Description == dto.Description);
        if (existCourseCategory != null)
            throw new AlreadyExistException("This CourseCategory is already exist with this Email");

        var mappedCourseCategory = _mapper.Map<CourseCategory>(dto);
        await _unitOfWork.CourseCategoryRepository.CreateAsync(mappedCourseCategory);
        await _unitOfWork.SaveAsync();

        var result = _mapper.Map<CourseCategoryResultDto>(mappedCourseCategory);
        return result;
    }

    public async Task<CourseCategoryResultDto> ModifyAsync(CourseCategoryUpdateDto dto)
    {
        CourseCategory existCourseCategory = await _unitOfWork.CourseCategoryRepository.SelectAsync(e => e.Id == dto.Id);
        if (existCourseCategory == null)
            throw new NotFoundException("This CourseCategory is not found with this id");

        _mapper.Map(dto, existCourseCategory);
        _unitOfWork.CourseCategoryRepository.Update(existCourseCategory);
        await _unitOfWork.SaveAsync();

        var result = _mapper.Map<CourseCategoryResultDto>(existCourseCategory);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        CourseCategory existCourseCategory = await _unitOfWork.CourseCategoryRepository.SelectAsync(e => e.Id == id);
        if (existCourseCategory == null)
            throw new NotFoundException("This CourseCategory is not found with this id");

        _unitOfWork.CourseCategoryRepository.Delete(existCourseCategory);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<CourseCategoryResultDto> RetrieveByIdAsync(long id)
    {
        CourseCategory existCourseCategory = await _unitOfWork.CourseCategoryRepository.SelectAsync(e => e.Id == id);
        if (existCourseCategory == null)
            throw new NotFoundException("This CourseCategory is not found with this id");

        var result = _mapper.Map<CourseCategoryResultDto>(existCourseCategory);
        return result;
    }

    public async Task<IEnumerable<CourseCategoryResultDto>> RetrieveAllAsync()
    {
        var query = await _unitOfWork.CourseCategoryRepository.SelectAll();
        var result = _mapper.Map<IEnumerable<CourseCategoryResultDto>>(query);
        return result;
    }
}
