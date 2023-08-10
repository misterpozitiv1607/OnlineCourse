using OnlineCourse.Domain.Enums;

namespace OnlineCourse.Service.Dtos.Orders;

public class OrderUpdateDto
{
    public long Id { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
