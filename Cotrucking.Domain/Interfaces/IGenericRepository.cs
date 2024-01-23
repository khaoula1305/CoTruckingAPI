using System.Linq.Expressions;

namespace Cotrucking.Domain
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsNoTrackingAsync();
        Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task<T?> FindAsync(Guid id);
        Task<T?> FindFirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task InsertAsync(T entity);
        Task InsertRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task<int> SaveChangesAsync();
    }
}
