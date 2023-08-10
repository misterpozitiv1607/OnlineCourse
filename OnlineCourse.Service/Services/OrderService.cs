using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.Repositories;
using OnlineCourse.Domain.Entities.Orders;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Interfaces;
using OnlineCourse.Service.Mappers;

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
    public async Task<Response<OrderResultDto>> CreateAsync(OrderCreationDto dto)
    {
        Order order = mapper.Map<Order>(dto);
        var existOrder = unitOfWork.OrderRepository.SelectAll().FirstOrDefault(u => u.PaymentCode.Equals(dto.paymentCode));

        if (existOrder is not null)
            return new Response<OrderResultDto>
            {
                StatusCode = 403,
                Message = $"This order allready exist PaymentCode:{existOrder.PaymentCode}"
            };

        await this.unitOfWork.OrderRepository.CreateAsync(order);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<OrderResultDto>(order);
        return new Response<OrderResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<OrderResultDto>> UpdateAsync(OrderUpdateDto dto)
    {
        Order existOrder = await this.unitOfWork.OrderRepository.SelectById(dto.Id);
        if (existOrder is null)
            return new Response<OrderResultDto>
            {
                StatusCode = 403,
                Message = $"This order is not found Id:{existOrder.Id}",
                Data = null
            };

        var mappedOrder = this.mapper.Map(dto, existOrder);
        this.unitOfWork.OrderRepository.Update(mappedOrder);
        this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<OrderResultDto>(mappedOrder);

        return new Response<OrderResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };

    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        Order existOrder = await this.unitOfWork.OrderRepository.SelectById(id);

        if (existOrder is null)
            return new Response<bool>
            {
                StatusCode = 403,
                Message = $"This order is not found Id:{existOrder.Id}",
                Data = false
            };
        this.unitOfWork.OrderRepository.Delete(existOrder);
        this.unitOfWork.SaveAsync();

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<OrderResultDto>> GetByIdAsync(long id)
    {
        Order existOrder = await this.unitOfWork.OrderRepository.SelectById(id);
        if (existOrder is null)
            return new Response<OrderResultDto>
            {
                StatusCode = 403,
                Message = $"This order is not found Id:{existOrder.Id}",
                Data = null
            };

        var result = this.mapper.Map<OrderResultDto>(existOrder);

        return new Response<OrderResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }


    public async Task<Response<List<OrderResultDto>>> GetAllAsync()
    {
        var orders = await this.unitOfWork.OrderRepository.SelectAll().ToListAsync();


        foreach (var item in orders)
        {
            Order order = await this.unitOfWork.OrderRepository.SelectById(item.Id);
        }

        var result = this.mapper.Map<IEnumerable<OrderResultDto>>(orders);
        return new Response<IEnumerable<StudentResultDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }    
}

