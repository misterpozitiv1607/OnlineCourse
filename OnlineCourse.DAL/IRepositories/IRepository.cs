using System.Linq.Expressions;
using OnlineCourse.Domain.Commons;

namespace OnlineCourse.DAL.IRepositories;

public interface IRepository<T> where T:Auditable
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> SelectAsync(Expression<Func<T, bool>> expression = null, string[] includes = null);
    Task<IQueryable<T>> SelectAll(Expression<Func<T, bool>> expression = null, bool isNoTracking = true, string[] includes = null);
}
