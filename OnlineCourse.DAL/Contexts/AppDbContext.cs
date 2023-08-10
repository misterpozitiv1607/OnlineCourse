using System;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Domain.Entities.CourseCategories;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Domain.Entities.Orders;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Domain.Entities.Teachers;
using OnlineCourse.Domain.Enums;

namespace OnlineCourse.DAL.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string Connoction_String = "Host=localhost;Port=5432; User Id = postgres; Password = mansurjon1607; Database=CourseDb; Include Error Detail=True;";
        optionsBuilder.UseNpgsql(Connoction_String);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Fluent Api
        modelBuilder.Entity<Course>()
            .HasOne(u => u.Student)
            .WithMany()
            .HasForeignKey(u => u.StudentId);

        modelBuilder.Entity<Course>()
            .HasOne(u => u.Teacher)
            .WithMany()
            .HasForeignKey(u => u.TeacherId);

        modelBuilder.Entity<Course>()
            .HasOne(u => u.Order)
            .WithMany()
            .HasForeignKey(u => u.OrderId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CourseCategory>()
            .HasOne(u => u.Course)
            .WithMany()
            .HasForeignKey(u => u.CourseId)
            .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region  Seet Data
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "Farruh", LastName = "Ulashov", DateOfBirth = new DateTimeOffset(new DateTime(2001, 09, 11)).UtcDateTime, Phone = "+998905201669", Email = "farruhulashov@gmail.com", CreatedAt = DateTime.UtcNow },
            new Student { Id = 2, FirstName = "Samandar", LastName = "Aliyev", DateOfBirth = new DateTimeOffset(new DateTime(2002, 08, 10)).UtcDateTime, Phone = "+998912024099", Email = "samandaraliyev@gmail.com", CreatedAt = DateTime.UtcNow },
            new Student { Id = 3, FirstName = "Nurullo", LastName = "Nurmatov", DateOfBirth = new DateTimeOffset(new DateTime(2003, 08, 06)).UtcDateTime, Phone = "+998942240816", Email = "nurullonurmatov@gmail.com", CreatedAt = DateTime.UtcNow },
            new Student { Id = 4, FirstName = "Nodirbek", LastName = "Norboyev", DateOfBirth = new DateTimeOffset(new DateTime(2002, 04, 13)).UtcDateTime, Phone = "+998903446861", Email = "nodirbeknorboyev@gmail.com", CreatedAt = DateTime.UtcNow },
            new Student { Id = 5, FirstName = "Abbosxon", LastName = "Risqulov", DateOfBirth = new DateTimeOffset(new DateTime(2003, 09, 11)).UtcDateTime, Phone = "+998911473900", Email = "abbosxonrisqulov1@gmail.com", CreatedAt = DateTime.UtcNow },
            new Student { Id = 6, FirstName = "Elbek", LastName = "Abdumannonov", DateOfBirth = new DateTimeOffset(new DateTime(2003, 06, 10)).UtcDateTime, Phone = "+998916861910", Email = "elbekabdumannonov@gmail.com", CreatedAt = DateTime.UtcNow },
            new Student { Id = 7, FirstName = "Manguberdi", LastName = "Mo'minov", DateOfBirth = new DateTimeOffset(new DateTime(2003, 04, 04)).UtcDateTime, Phone = "+998999941696", Email = "manguberdimominov@gmail.com", CreatedAt = DateTime.UtcNow },
            new Student { Id = 8, FirstName = "Mansurjon", LastName = "Mo'ydinov", DateOfBirth = new DateTimeOffset(new DateTime(2002, 07, 11)).UtcDateTime, Phone = "+998908515979", Email = "mansurjonmoydinov1@gmail.com", CreatedAt = DateTime.UtcNow },
            new Student { Id = 9, FirstName = "Xayrulla", LastName = "Eshqobilov", DateOfBirth = new DateTimeOffset(new DateTime(2003, 11, 11)).UtcDateTime, Phone = "+998942224468", Email = "xayrullaeshqobilov1@gmail.com", CreatedAt = DateTime.UtcNow },
            new Student { Id = 10, FirstName = "Samandar", LastName = "Abdunazarov", DateOfBirth = new DateTimeOffset(new DateTime(2003, 03, 04)).UtcDateTime, Phone = "+998888103636", Email = "samandarabdunazarov@gmail.com", CreatedAt = DateTime.UtcNow }
            );
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, PaymentMethod = PaymentMethod.Uzcard, IsPaymment = true, CreatedAt = DateTime.UtcNow}
            );

        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { Id = 2, FirstName = "Jamshid", LastName = "Maruf", Phone = "+998 97 577 75 52", Email = "jamshidmaruf@gmail.com", Speciality = ".Net", TeacherLevel = TeacherLevel.Middle, Experince = 3, DateOfBirth = new DateTimeOffset(new DateTime(1998, 02, 02)).UtcDateTime, CreatedAt = DateTime.UtcNow },
            new Teacher { Id = 3, FirstName = "Alisher", LastName = "Kasimov", Phone = "+998990787878", Email = "alisherkasimov@gmail.com", Speciality = "Foundation", TeacherLevel = TeacherLevel.Senior, DateOfBirth = new DateTimeOffset(new DateTime(1986, 09, 09)).UtcDateTime, Experince = 7, CreatedAt = DateTime.UtcNow }
           );

        modelBuilder.Entity<Course>().HasData(
            new Course { Id=1, Price=11150000, StartDate = new DateTimeOffset(new DateTime(2023, 06, 07)).UtcDateTime, EndDate = new DateTimeOffset( new DateTime(2023, 10, 28)).UtcDateTime, StudentId = 8, TeacherId = 2, OrderId = 1, CreatedAt = DateTime.UtcNow}
            );

        modelBuilder.Entity<CourseCategory>().HasData(
            new CourseCategory { Id = 1, Name = ".Net", Description = ".Net is Cross Platform", CourseId = 1, CreatedAt = DateTime.Now },
            new CourseCategory { Id = 2, Name = "Foundation", Description = "Foundation is beginner program!", CourseId = 1, CreatedAt = DateTime.Now }
            );

        #endregion
    }
}
