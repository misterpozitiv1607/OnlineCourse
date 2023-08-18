using AutoMapper;
using OnlineCourse.Service.Mappers;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.Repositories;
using OnlineCourse.Service.Interfaces;
using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Domain.Entities.Orders;

namespace OnlineCourse.Service.Services;

public class OrderService : IOrderService
{
    private readonly Mapper mapper;
    private readonly UnitOfWork unitOfWork;

    public OrderService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));

    }
    public async Task<OrderResultDto> AddAsync(OrderCreationDto dto)
    {
        Order order = mapper.Map<Order>(dto);
        var existOrder = unitOfWork.OrderRepository.SelectAll().FirstOrDefault(u => u.PaymentCode.Equals(dto.paymentCode));

        if (existOrder is not null)
            return null;

        await this.unitOfWork.OrderRepository.CreateAsync(order);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<OrderResultDto>(order);
        return result;
    }

    public async Task<OrderResultDto> ModifyAsync(OrderUpdateDto dto)
    {
        Order existOrder = await this.unitOfWork.OrderRepository.SelectById(dto.Id);
        if (existOrder is null)
            return null;

        var mappedOrder = this.mapper.Map(dto, existOrder);
        this.unitOfWork.OrderRepository.Update(mappedOrder);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<OrderResultDto>(mappedOrder);

        return result;

    }

    public async Task<bool> RemoveAsync(long id)
    {
        Order existOrder = await this.unitOfWork.OrderRepository.SelectById(id);

        if (existOrder is null)
            return false;
        this.unitOfWork.OrderRepository.Delete(existOrder);
        this.unitOfWork.SaveAsync();

        return true;
    }

    public async Task<OrderResultDto> RetrieveByIdAsync(long id)
    {
        Order existOrder = await this.unitOfWork.OrderRepository.SelectById(id);
        if (existOrder is null)
            return null;

        var result = this.mapper.Map<OrderResultDto>(existOrder);

        return result;
    }


    public async Task<IEnumerable<OrderResultDto>> RetrieveAllAsync()
    {
        var orders = await this.unitOfWork.OrderRepository.SelectAll().ToListAsync();


        foreach (var item in orders)
        {
            Order order = await this.unitOfWork.OrderRepository.SelectById(item.Id);
        }

        var result = this.mapper.Map<IEnumerable<OrderResultDto>>(orders);
        return result;
    }   
    
}

