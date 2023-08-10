using OnlineCourse.Domain.Commons;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Domain.Enums;

namespace OnlineCourse.Domain.Entities.Orders;

public class Order:Auditable
{
    public PaymentMethod PaymentMethod { get; set; }
    public bool IsPaymment { get; set; }
}
