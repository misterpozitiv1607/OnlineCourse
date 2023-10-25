using Microsoft.EntityFrameworkCore;
using OnlineCourse.Domain.Entities.Orders;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Domain.Entities.Teachers;
using OnlineCourse.Domain.Entities.CourseCategories;

namespace OnlineCourse.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseCategory> LessonProgress { get; set; }
    public DbSet<Order> Lessons { get; set; }
}
