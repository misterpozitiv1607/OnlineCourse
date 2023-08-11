using OnlineCourse.Domain.Enums;
using OnlineCourse.Domain.Commons;

namespace OnlineCourse.Domain.Entities.Orders;

public class Order:Auditable
{
    public int PaymentCode { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public bool IsPaymment { get; set; }
}
