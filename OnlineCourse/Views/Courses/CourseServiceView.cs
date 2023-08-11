using OnlineCourse.Service.Dtos.Courses;
using OnlineCourse.Service.Dtos.Teachers;
using OnlineCourse.Service.Services;

namespace OnlineCourse.Views.Courses;

public class CourseServiceView
{
    private CourseService courseService = new();
    public async void Create()
    {
        Console.WriteLine("Price: ");
        double price = double.Parse(Console.ReadLine());

        Console.WriteLine("StartDate(example:yyyy-mm-dd): ");
        DateTime start_date_time = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("EndDate");
        DateTime end_date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("StudentId: ");
        long studentId = long.Parse(Console.ReadLine());

        Console.WriteLine("StudentId: ");
        long orderId = long.Parse(Console.ReadLine());

        Console.WriteLine("StudentId: ");
        long teacherId = long.Parse(Console.ReadLine());


        var result = await courseService.CreateAsync(new CourseCreationDto
        {
            Price = price,
            StartDate = start_date_time,
            EndDate = end_date,
            StudentId = studentId,
            OrderId = orderId,
            TeacherId = teacherId
        });

        if (result.StatusCode == 200)
            Console.WriteLine(result.Data.Price+" " + result.Data.StudentResultDto.ToString().Count()+" " + result.Data.TeacherResultDto.FirstName+" " + result.Data.TeacherResultDto.LastName);
    }

    public async void Update()
    {
        Console.WriteLine("Price: ");
        double price = double.Parse(Console.ReadLine());

        Console.WriteLine("StartDate(example:yyyy-mm-dd): ");
        DateTime start_date_time = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("EndDate");
        DateTime end_date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("StudentId: ");
        long studentId = long.Parse(Console.ReadLine());

        Console.WriteLine("StudentId: ");
        long orderId = long.Parse(Console.ReadLine());

        Console.WriteLine("StudentId: ");
        long teacherId = long.Parse(Console.ReadLine());


        var result = await courseService.UpdateAsync(new CourseUpdateDto
        {
            Price = price,
            StartDate = start_date_time,
            EndDate = end_date,
            StudentId = studentId,
            OrderId = orderId,
            TeacherId = teacherId
        });

        if (result.StatusCode == 200)
            Console.WriteLine(result.Data.Price + " " + result.Data.StudentResultDto.ToString().Count() + " " + result.Data.TeacherResultDto.FirstName + " " + result.Data.TeacherResultDto.LastName);
    }

    public async void Delete()
    {
        Console.WriteLine("Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = await courseService.DeleteAsync(id);
        Console.WriteLine(result.StatusCode);

    }

    public async void GetById()
    {
        Console.WriteLine("Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = await courseService.GetByIdAsync(id);
        Console.WriteLine(result.Data.Price + " " + result.Data.StudentResultDto.ToString().Count() + " " + result.Data.TeacherResultDto.FirstName + " " + result.Data.TeacherResultDto.LastName);

    }

    public async Task GetAll()
    {
        var result = await courseService.GetAllAsync();

        foreach (var item in result.Data)
            Console.WriteLine(item.Price + " " + item.StudentResultDto.ToString().Count() + " " + item.TeacherResultDto.FirstName + " " + item.TeacherResultDto.LastName);
    }
}
