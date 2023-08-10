using OnlineCourse.DAL.Contexts;
using OnlineCourse.DAL.IRepositories;
using OnlineCourse.Domain.Entities.Students;
using System;

namespace OnlineCourse.DAL.Repositories;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext appDbContex;

    public IRepository<Student> StudentRepository { get; }

    public UnitOfWork()
    {
        appDbContex = new AppDbContext();
        StudentRepository = new Repository<Student>();
        OrderRepository = new Repository<WorkOut>();
        NutritionPlanRepository = new Repository<NutritionPlan>();
        ProgressRecordRepository = new Repository<ProgressRecord>();
    }
    public IRepository<WorkOut> OrderRepository { get; }

    public IRepository<ProgressRecord> ProgressRecordRepository { get; }

    public IRepository<NutritionPlan> NutritionPlanRepository { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task SaveAsync()
    {
        await this.appDbContex.SaveChangesAsync();
    }
}
