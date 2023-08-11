using OnlineCourse.Domain.Entities.Orders;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Domain.Entities.Teachers;
using OnlineCourse.Domain.Entities.CourseCategories;


namespace OnlineCourse.DAL.IRepositories;

public interface IUnitOfWork
{
    IRepository<Student> StudentRepository { get; }
    IRepository<Teacher> TeacherRepository { get; }
    IRepository<Course> CourseRepository { get; }
    IRepository<CourseCategory> CourseCategoryRepository { get; }
    IRepository<Order> OrderRepository { get; }
    Task SaveAsync();
}
