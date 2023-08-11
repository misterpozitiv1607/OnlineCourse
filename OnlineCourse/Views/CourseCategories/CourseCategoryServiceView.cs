using OnlineCourse.Domain.Enums;
using OnlineCourse.Service.Dtos.Orders;
using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Services;

namespace OnlineCourse.Views.CourseCategories;

public class CourseCategoryServiceView
{
    private StudentService studentService = new();
    public async void Create()
    {
        Console.WriteLine("FirstName: ");
        string first_name = Console.ReadLine();

        Console.WriteLine("LastName: ");
        string last_name = Console.ReadLine();

        Console.WriteLine("Date Of Birth(example:yyyy-mm-dd)");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Phone(example:+998xxxxxxxxx)");
        string phone = Console.ReadLine();

        Console.WriteLine("Email(example:example@gmail.com): ");
        string email = Console.ReadLine();

        var result = await studentService.CreateAsync(new StudentCreationDto
        {
            FirstName = first_name,
            LastName = last_name,
            DateOfBirth = date,
            Phone = phone,
            Email = email
        });

        if (result.StatusCode == 200)
            Console.WriteLine(result.Data.FirstName);
    }

    public async void Update()
    {
        Console.WriteLine("Id: ");
        long id = long.Parse(Console.ReadLine());

        Console.WriteLine("FirstName: ");
        string first_name = Console.ReadLine();

        Console.WriteLine("LastName: ");
        string last_name = Console.ReadLine();

        Console.WriteLine("Date Of Birth(example:yyyy-mm-dd)");
        DateTime date = DateTimeOffset.Parse(DateTime.Parse(Console.ReadLine()).ToString()).UtcDateTime;


        Console.WriteLine("Phone(example:+998xxxxxxxxx)");
        string phone = Console.ReadLine();

        Console.WriteLine("Email(example:example@gmail.com): ");
        string email = Console.ReadLine();

        StudentUpdateDto studentUpdateDto = new StudentUpdateDto()
        {
            Id = id,
            FirstName = first_name,
            LastName = last_name,
            DateOfBirth = date,
            Phone = phone,
            Email = email
        };

        await studentService.UpdateAsync(studentUpdateDto);

    }

    public async void Delete()
    {
        Console.WriteLine("Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = await studentService.DeleteAsync(id);
        Console.WriteLine(result.StatusCode);

    }

    public async void GetById()
    {
        Console.WriteLine("Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = await studentService.GetByIdAsync(id);
        Console.WriteLine(result.Message);

    }

    public async Task GetAll()
    {
        var result = await studentService.GetAllAsync();

        foreach (var item in result.Data)
            Console.WriteLine(item.FirstName);
    }
}
