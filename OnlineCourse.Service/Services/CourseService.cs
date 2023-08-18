using AutoMapper;
using OnlineCourse.DAL.IRepositories;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Service.Dtos.Courses;
using OnlineCourse.Service.Exceptions;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Service.Services;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CourseResultDto> AddAsync(CourseCreationDto dto)
    {
        Course existCourse = await _unitOfWork.CourseRepository.SelectAsync(e => e.StudentId == dto.StudentId && e.OrderId ==dto.OrderId);
        if (existCourse != null)
            throw new AlreadyExistException("This Course is already exist with this Id's");

        var mappedCourse = _mapper.Map<Course>(dto);
        await _unitOfWork.CourseRepository.CreateAsync(mappedCourse);
        await _unitOfWork.SaveAsync();

        var result = _mapper.Map<CourseResultDto>(mappedCourse);
        return result;
    }

    public async Task<CourseResultDto> ModifyAsync(CourseUpdateDto dto)
    {
        Course existCourse = await _unitOfWork.CourseRepository.SelectAsync(e => e.Id == dto.Id);
        if (existCourse == null)
            throw new NotFoundException("This Course is not found with this id");

        _mapper.Map(dto, existCourse);
        _unitOfWork.CourseRepository.Update(existCourse);
        await _unitOfWork.SaveAsync();

        var result = _mapper.Map<CourseResultDto>(existCourse);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Course existCourse = await _unitOfWork.CourseRepository.SelectAsync(e => e.Id == id);
        if (existCourse == null)
            throw new NotFoundException("This Course is not found with this id");

        _unitOfWork.CourseRepository.Delete(existCourse);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<CourseResultDto> RetrieveByIdAsync(long id)
    {
        Course existCourse = await _unitOfWork.CourseRepository.SelectAsync(e => e.Id == id);
        if (existCourse == null)
            throw new NotFoundException("This Course is not found with this id");

        var result = _mapper.Map<CourseResultDto>(existCourse);
        return result;
    }

    public async Task<IEnumerable<CourseResultDto>> RetrieveAllAsync()
    {
        var query = await _unitOfWork.CourseRepository.SelectAll();
        var result = _mapper.Map<IEnumerable<CourseResultDto>>(query);
        return result;
    }
}
