namespace ProductApi.Infrastructure.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IQueryable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(long id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(long id);
}
