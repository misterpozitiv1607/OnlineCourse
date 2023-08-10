using OnlineCourse.Service.Dtos.Students;
using OnlineCourse.Service.Services;

StudentService studentService = new StudentService();

StudentCreationDto studentCreationDto = new StudentCreationDto()
{
    FirstName = "Madiyor",
    LastName = "Odilov",
    DateOfBirth = new DateTime(2005, 01, 02),
    Phone = "+998908765432",
    Email = "madiyorodilov@gmail.com"
};
//var result = (await studentService.CreateAsync(studentCreationDto));

//Console.WriteLine(result.Data.FirstName);

var res = await studentService.GetAllAsync();
foreach(var item in res.Data)
    Console.WriteLine(item.FirstName);