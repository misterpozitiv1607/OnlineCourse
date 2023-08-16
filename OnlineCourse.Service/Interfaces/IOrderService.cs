using OnlineCourse.Service.Dtos.Orders;

namespace OnlineCourse.Service.Interfaces;

public interface IOrderService
{
    Task<OrderResultDto> AddAsync(OrderCreationDto dto);
    Task<OrderResultDto> ModifyAsync(OrderUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<OrderResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<OrderResultDto>> RetrieveAllAsync();
}
