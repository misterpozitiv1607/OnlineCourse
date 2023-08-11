using OnlineCourse.Service.Dtos.CourseCategories;
using OnlineCourse.Service.Services;

namespace OnlineCourse.Views.CourseCategories;

public class CourseCategoryServiceView
{
    private CourseCategoryService coursecategoryService = new();
    public async void Create()
    {
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Description: ");
        string description = Console.ReadLine();

        Console.WriteLine("CourseId)");
        long id = long.Parse(Console.ReadLine());

        var result = await coursecategoryService.CreateAsync(new CourseCategoryCreationDto
        {
            Name = name,
            Description = description,
            CourseId = id
        });

        if (result.StatusCode == 200)
            Console.WriteLine(result.Data.Name+" " + result.Data.Description+" " + result.Data.ToString().Count());
    }

    public async void Update()
    {
        Console.WriteLine("Id: ");
        long Id = long.Parse(Console.ReadLine());

        Console.WriteLine("Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Description: ");
        string description = Console.ReadLine();

        Console.WriteLine("CourseId)");
        long id = long.Parse(Console.ReadLine());

        CourseCategoryUpdateDto courseCategoryUpdateDto = new CourseCategoryUpdateDto 
        { 
            Id = Id,
            Name = name,
            Description = description,
            CourseId = id
        };
        var result = await coursecategoryService.UpdateAsync(courseCategoryUpdateDto);
        if (result.StatusCode == 200)
            Console.WriteLine(result.Data.Name + " " + result.Data.Description + " " + result.Data.ToString().Count());
    }

    public async void Delete()
    {
        Console.WriteLine("Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = await coursecategoryService.DeleteAsync(id);
        Console.WriteLine(result.Message);
    }

    public async void GetById()
    {
        Console.WriteLine("Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = await coursecategoryService.GetByIdAsync(id);
        Console.WriteLine(result.Data.Name + " " + result.Data.Description + " " + result.Data.ToString().Count());

    }

    public async Task GetAll()
    {
        var result = await coursecategoryService.GetAllAsync();

        foreach (var item in result.Data)
            Console.WriteLine(item.Name + " " + item.Description + " " + item.ToString().Count());
    }
}
