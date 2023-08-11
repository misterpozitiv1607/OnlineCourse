using OnlineCourse.Service.Services;
using OnlineCourse.Service.Dtos.Students;


namespace OnlineCourse.Views.Students;

public class StudentServiceView
{
    private StudentService studentService = new();
    public async void Create()
    {
        int count = 0;
        Console.WriteLine(@"1.23*0+90 = ?
A. 90
B. 113
C. 0");
        Console.WriteLine("To'g'ri javobni kiriting(A,B,C)");
        string choice = Console.ReadLine();
        if (choice == "A" || choice == "a")
            count += 1;
        Console.WriteLine(@"2.23+0*90 = ?
A. 90
B. 113
C. 23");
        Console.WriteLine("To'g'ri javobni kiriting(A,B,C)");
        string choice1 = Console.ReadLine();
        if (choice1 == "C" || choice == "c")
            count += 1;
        Console.WriteLine(@"3.100/20 = ?
A. 5
B. 10
C. 0");
        Console.WriteLine("To'g'ri javobni kiriting(A,B,C)");
        string choice2 = Console.ReadLine();
        if (choice2 == "A" || choice2 == "a")
            count += 1;
        Console.WriteLine(@"4.110*5 = ?
A. 550
B. 113
C. 390");
        Console.WriteLine("To'g'ri javobni kiriting(A,B,C)");
        string choice3 = Console.ReadLine();
        if (choice3 == "A" || choice3 == "a")
            count += 1;
        Console.WriteLine(@"5.1100-600 = ?
A. 500
B. 400
C. 403");
        Console.WriteLine("To'g'ri javobni kiriting(A,B,C)");
        string choice4 = Console.ReadLine();
        if (choice4 == "A" || choice4 == "a")
            count += 1;

        if (count == 5)
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
        else
        {
            Console.WriteLine("Sizda xali matematik bilimlar yetarli darajada emas!");
        }
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
