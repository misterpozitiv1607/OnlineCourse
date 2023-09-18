﻿using OnlineCourse.DAL.Contexts;
using OnlineCourse.DAL.IRepositories;
using OnlineCourse.Domain.Entities.Orders;
using OnlineCourse.Domain.Entities.Courses;
using OnlineCourse.Domain.Entities.Students;
using OnlineCourse.Domain.Entities.Teachers;
using OnlineCourse.Domain.Entities.CourseCategories;

namespace OnlineCourse.DAL.Repositories;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext _dbContex;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContex = dbContext;
        StudentRepository = new Repository<Student>(_dbContex);
        OrderRepository = new Repository<Order>(_dbContex);
        CourseRepository = new Repository<Course>(_dbContex);
        CourseCategoryRepository = new Repository<CourseCategory>(_dbContex);
        TeacherRepository = new Repository<Teacher>(_dbContex);
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
        await this._dbContex.SaveChangesAsync();
    }
}
