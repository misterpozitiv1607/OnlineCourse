using AutoMapper;
using OnlineCourse.DAL.IRepositories;
using OnlineCourse.Domain.Entities.Teachers;
using OnlineCourse.Service.Dtos.Teachers;
using OnlineCourse.Service.Exceptions;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Service.Services;

public class TeacherService : ITeacherService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TeacherResultDto> AddAsync(TeacherCreationDto dto)
    {
        Teacher existTeacher = await _unitOfWork.TeacherRepository.SelectAsync(e => e.Email == dto.Email);
        if (existTeacher != null)
            throw new AlreadyExistException("This Teacher is already exist with this Email");

        var mappedTeacher = _mapper.Map<Teacher>(dto);
        await _unitOfWork.TeacherRepository.CreateAsync(mappedTeacher);
        await _unitOfWork.SaveAsync();

        var result = _mapper.Map<TeacherResultDto>(mappedTeacher);
        return result;
    }

    public async Task<TeacherResultDto> ModifyAsync(TeacherUpdateDto dto)
    {
        Teacher existTeacher = await _unitOfWork.TeacherRepository.SelectAsync(e => e.Id == dto.Id);
        if (existTeacher == null)
            throw new NotFoundException("This Teacher is not found with this id");

        _mapper.Map(dto, existTeacher);
        _unitOfWork.TeacherRepository.Update(existTeacher);
        await _unitOfWork.SaveAsync();

        var result = _mapper.Map<TeacherResultDto>(existTeacher);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Teacher existTeacher = await _unitOfWork.TeacherRepository.SelectAsync(e => e.Id == id);
        if (existTeacher == null)
            throw new NotFoundException("This Teacher is not found with this id");

        _unitOfWork.TeacherRepository.Delete(existTeacher);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<TeacherResultDto> RetrieveByIdAsync(long id)
    {
        Teacher existTeacher = await _unitOfWork.TeacherRepository.SelectAsync(e => e.Id == id);
        if (existTeacher == null)
            throw new NotFoundException("This Teacher is not found with this id");

        var result = _mapper.Map<TeacherResultDto>(existTeacher);
        return result;
    }

    public async Task<IEnumerable<TeacherResultDto>> RetrieveAllAsync()
    {
        var query = await _unitOfWork.TeacherRepository.SelectAll();
        var result = _mapper.Map<IEnumerable<TeacherResultDto>>(query);
        return result;
    }
}
