using System.Linq.Expressions;

namespace testforBohdan.Repository.IRepository;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    Task<T> GetAsync(Expression<Func<T, bool>>? filter = null);
    Task CreateAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveAsync();
}