using OnlineCourse.Web.Pages;

namespace OnlineCourse.Web.Service.Interfaces
{
    public interface IStudentService
    {
        Task<Student> AddAsync(Student dto);
        Task<Student> ModifyAsync(Student dto);
        Task<bool> RemoveAsync(long id);
        Task<Student> RetrieveByIdAsync(long id);
        Task<IEnumerable<Student>> RetrieveAllAsync();
    }
}
