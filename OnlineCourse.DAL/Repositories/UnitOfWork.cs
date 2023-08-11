using OnlineCourse.DAL.Contexts;
using OnlineCourse.DAL.IRepositories;
using OnlineCourse.Domain.Entities.Orders;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Domain.Entities.Teachers;
using OnlineCourse.Domain.Entities.CourseCategories;

namespace OnlineCourse.DAL.Repositories;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext appDbContex;
    public UnitOfWork()
    {
        appDbContex = new AppDbContext();
        StudentRepository = new Repository<Student>(appDbContex);
        OrderRepository = new Repository<Order>(appDbContex);
        CourseRepository = new Repository<Course>(appDbContex);
        CourseCategoryRepository = new Repository<CourseCategory>(appDbContex);
        TeacherRepository = new Repository<Teacher>(appDbContex);
    }
    public IRepository<Order> OrderRepository { get; }
    public IRepository<Student> StudentRepository { get; }

    public IRepository<Course> CourseRepository { get; }
    public IRepository<Teacher> TeacherRepository { get; }
    public IRepository<CourseCategory> CourseCategoryRepository { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task SaveAsync()
    {
        await this.appDbContex.SaveChangesAsync();
    }
}
