using OnlineCourse.Domain.Commons;

namespace OnlineCourse.DAL.IRepositories.GenericIRepository;

public interface IRepository<T> where T : Auditable
{
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> SelectByIdAsync(long id);
    IQueryable<T> SelectAll();
}
