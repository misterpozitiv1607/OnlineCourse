using OnlineCourse.Web.Models;
using OnlineCourse.Web.Service.Interfaces;

namespace OnlineCourse.Web.Service.Services;

public class StudentService : IStudentService
{
    public Task<Student> AddAsync(Student dto)
    {
        throw new NotImplementedException();
    }

    public Task<Student> ModifyAsync(Student dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Student>> RetrieveAllAsync()
    {
        var httpClient = new HttpClient();
        string url = "http://localhost:5248/api/Student/GetAll";
        var content = await httpClient.GetAsync(url);
        var result =  content.Content.ReadAsStringAsync();
        return (IEnumerable<Student>)result;
    }
    
    public Task<Student> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
