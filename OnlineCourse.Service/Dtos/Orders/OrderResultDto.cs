using OnlineCourse.Domain.Enums;

namespace OnlineCourse.Service.Dtos.Orders;

public class OrderResultDto
{
    public long Id { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public bool IsPaymment { get; set; }
}