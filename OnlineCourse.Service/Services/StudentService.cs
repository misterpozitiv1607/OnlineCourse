using AutoMapper;
using OnlineCourse.DAL.IRepositories;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Exceptions;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Service.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<StudentResultDto> AddAsync(StudentCreationDto dto)
    {
        Student existStudent = await _unitOfWork.StudentRepository.SelectAsync(e => e.Email == dto.Email);
        if (existStudent != null)
            throw new AlreadyExistException("This Student is already exist with this Email");

        var mappedStudent = _mapper.Map<Student>(dto);
        await _unitOfWork.StudentRepository.CreateAsync(mappedStudent);
        mappedStudent.CreatedAt = DateTime.UtcNow.AddHours(0);
        await _unitOfWork.SaveAsync();

        var result = _mapper.Map<StudentResultDto>(mappedStudent);
        return result;
    }

    public async Task<StudentResultDto> ModifyAsync(StudentUpdateDto dto)
    {
        Student existStudent = await _unitOfWork.StudentRepository.SelectAsync(e => e.Id == dto.Id);
        if (existStudent == null)
            throw new NotFoundException("This Student is not found with this id");

        _mapper.Map(dto, existStudent);
        _unitOfWork.StudentRepository.Update(existStudent);
        _mapper.Map(dto, existStudent).UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveAsync();

        var result = _mapper.Map<StudentResultDto>(existStudent);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Student existStudent = await _unitOfWork.StudentRepository.SelectAsync(e => e.Id == id);
        if (existStudent == null)
            throw new NotFoundException("This Student is not found with this id");

        _unitOfWork.StudentRepository.Delete(existStudent);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<StudentResultDto> RetrieveByIdAsync(long id)
    {
        Student existStudent = await _unitOfWork.StudentRepository.SelectAsync(e => e.Id == id);
        if (existStudent == null)
            throw new NotFoundException("This Student is not found with this id");

        var result = _mapper.Map<StudentResultDto>(existStudent);
        return result;
    }

    public async Task<IEnumerable<StudentResultDto>> RetrieveAllAsync()
    {
        var query = await _unitOfWork.StudentRepository.SelectAll();
        var result = _mapper.Map<IEnumerable<StudentResultDto>>(query);
        return result;
    }
}
