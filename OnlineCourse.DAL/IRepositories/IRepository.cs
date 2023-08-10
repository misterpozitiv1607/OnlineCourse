using OnlineCourse.Domain.Commons;

namespace OnlineCourse.DAL.IRepositories;

public interface IRepository<T> where T:Auditable
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> SelectById(long id);
    IQueryable<T> SelectAll();
}
