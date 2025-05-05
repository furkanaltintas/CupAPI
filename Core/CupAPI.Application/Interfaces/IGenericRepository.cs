namespace CupAPI.Application.Interfaces;

public interface IGenericRepository<T> where T : class, new()
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);

    IQueryable<T> Query();
}
