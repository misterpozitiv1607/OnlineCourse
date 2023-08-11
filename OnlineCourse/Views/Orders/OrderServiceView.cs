using OnlineCourse.Domain.Enums;
using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineCourse.Views.Orders;

public class OrderServiceView
{
    private OrderService orderService = new();
    public async void Create()
    {
            //public int paymentCode;
            //public PaymentMethod PaymentMethod;
        Console.WriteLine("PaymentCode: ");
        int payment_code = int.Parse(Console.ReadLine());

        Console.WriteLine(@"Quyidagilarga mos son kiriting:
1.Uzcard
2.Humo,
3.MasterCard,
4.Visa");
        OrderCreationDto orderCreationDto = new OrderCreationDto();
        PaymentMethod paymentMethod = 0;
        int number = int.Parse(Console.ReadLine());
        switch (number)
        {
            case 1:
                paymentMethod = PaymentMethod.Uzcard;
                break;
            case 2:
                paymentMethod = PaymentMethod.Humo;
                break;
            case 3:
                paymentMethod = PaymentMethod.MasterCard;
                break;
            case 4:
                paymentMethod = PaymentMethod.Visa;
                break;
            default:
                Console.WriteLine("Error!");
                break;
        }
    }

    public async void Update()
    {
        Console.WriteLine("Id: ");
        long id = long.Parse(Console.ReadLine());

        Console.WriteLine("FirstName: ");
        string first_name = Console.ReadLine();

        Console.WriteLine("IsPayment(true or false enter: )");
        bool ispayment = bool.Parse(Console.ReadLine());

        OrderUpdateDto orderUpdateDto = new OrderUpdateDto()
        {
            Id = id,
            IsPayment = ispayment
        };

        await orderService.UpdateAsync(orderUpdateDto);

    }

    public async void Delete()
    {
        Console.WriteLine("Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = await orderService.DeleteAsync(id);
        Console.WriteLine(result.StatusCode);

    }

    public async void GetById()
    {
        Console.WriteLine("Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = await orderService.GetByIdAsync(id);
        Console.WriteLine(result.Message);

    }

    public async Task GetAll()
    {
        var result = await orderService.GetAllAsync();

        foreach (var item in result.Data)
            Console.WriteLine(item.PaymentMethod + " " + item.Id+" "+ item.IsPaymment);
    }
}
