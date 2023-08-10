using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Service.Helpers;
using OnlineCourse.Service.Interfaces;

namespace OnlineCourse.Service.Services;

public class OrderService : IOrderService
{
    public Task<Response<OrderResultDto>> CreateAsync(OrderCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<OrderResultDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<OrderResultDto>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<OrderResultDto>> UpdateAsync(OrderUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
