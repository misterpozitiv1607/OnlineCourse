using System.ComponentModel;
using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Helpers;

namespace OnlineCourse.Service.Interfaces;

public interface IOrderService
{
    Task<Response<OrderResultDto>> CreateAsync(OrderCreationDto dto);
    Task<Response<OrderResultDto>> UpdateAsync(OrderUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<OrderResultDto>> GetByIdAsync(long id);
    Task<Response<IEnumerable<OrderResultDto>>> GetAllAsync();
}
