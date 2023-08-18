using AutoMapper;
using OnlineCourse.DAL.IRepositories;
using OnlineCourse.Domain.Entities.Orders;
using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Service.Exceptions;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Service.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OrderResultDto> AddAsync(OrderCreationDto dto)
    {
        Order existOrder = await _unitOfWork.OrderRepository.SelectAsync(e => e.PaymentMethod == dto.PaymentMethod && e.PaymentCode==dto.paymentCode);
        if (existOrder != null)
            throw new AlreadyExistException("This Order is already exist with this Email");

        var mappedTeacher = _mapper.Map<Order>(dto);
        await _unitOfWork.OrderRepository.CreateAsync(mappedTeacher);
        await _unitOfWork.SaveAsync();

        var result = _mapper.Map<OrderResultDto>(mappedTeacher);
        return result;
    }

    public async Task<OrderResultDto> ModifyAsync(OrderUpdateDto dto)
    {
        Order existOrder = await _unitOfWork.OrderRepository.SelectAsync(e => e.Id == dto.Id);
        if (existOrder == null)
            throw new NotFoundException("This Order is not found with this id");

        _mapper.Map(dto, existOrder);
        _unitOfWork.OrderRepository.Update(existOrder);
        await _unitOfWork.SaveAsync();

        var result = _mapper.Map<OrderResultDto>(existOrder);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Order existOrder = await _unitOfWork.OrderRepository.SelectAsync(e => e.Id == id);
        if (existOrder == null)
            throw new NotFoundException("This Order is not found with this id");

        _unitOfWork.OrderRepository.Delete(existOrder);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<OrderResultDto> RetrieveByIdAsync(long id)
    {
        Order existOrder = await _unitOfWork.OrderRepository.SelectAsync(e => e.Id == id);
        if (existOrder == null)
            throw new NotFoundException("This Order is not found with this id");

        var result = _mapper.Map<OrderResultDto>(existOrder);
        return result;
    }

    public async Task<IEnumerable<OrderResultDto>> RetrieveAllAsync()
    {
        var query = await _unitOfWork.OrderRepository.SelectAll();
        var result = _mapper.Map<IEnumerable<OrderResultDto>>(query);
        return result;
    }
}
