using OnlineCourse.DAL.Contexts;
using OnlineCourse.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.DAL.IRepositories;
using System.Linq.Expressions;

namespace OnlineCourse.DAL.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression = null, string[] includes = null)
    {
        IQueryable<T> query = _dbSet.Where(expression).AsQueryable();
        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        var entity = await query.FirstOrDefaultAsync(expression);
        return entity;
    }

    public async Task<IQueryable<T>> SelectAll(Expression<Func<T, bool>> expression = null, bool isNoTracking = true, string[] includes = null)
    {
        IQueryable<T> query = expression is null ? _dbSet.AsQueryable() : _dbSet.Where(expression).AsQueryable();

        query = isNoTracking ? query.AsNoTracking() : query;

        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return query;
    }
}
