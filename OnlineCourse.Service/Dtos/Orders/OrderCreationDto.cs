using OnlineCourse.Domain.Enums;

namespace OnlineCourse.Service.Dtos.Orders;

public class OrderCreationDto
{
    public PaymentMethod PaymentMethod { get; set; }
}
