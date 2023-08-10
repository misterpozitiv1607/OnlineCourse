using OnlineCourse.Domain.Enums;

namespace OnlineCourse.Service.Dtos.Orders;

public class OrderCreationDto
{
    public int paymentCode { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
