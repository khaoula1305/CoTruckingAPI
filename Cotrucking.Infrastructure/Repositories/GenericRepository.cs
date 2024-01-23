using Cotrucking.Domain;
using Cotrucking.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Cotrucking.Infrastructure.Repositories
{
    public class GenericRepository<T>(CotruckingDbContext context, IHttpContextAccessor httpContext) : IGenericRepository<T> where T : class
    {
        readonly DbSet<T> _entities = context.Set<T>();
        readonly CotruckingDbContext _context = context;
        private readonly IHttpContextAccessor _accessor = httpContext;

        public Task DeleteAsync(T entity)
        {
            _entities.Remove(entity);
            return Task.CompletedTask;
        }
        
        public Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return Task.FromResult( _entities.Where(expression).AsQueryable());
        }

        public async Task<T?> FindAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T?> FindFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _entities.Where(expression).FirstOrDefaultAsync();
        }

        public Task<IQueryable<T>> GetAllAsNoTrackingAsync()
        {
            return Task.FromResult(_entities.AsNoTracking());
        }

        public Task<IQueryable<T>> GetAllAsync()
        {
            return Task.FromResult(_entities.AsQueryable());
        }

        public async Task InsertAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _entities.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            SetTrackColumns();
            return await _context.SaveChangesAsync();
        }

        private void SetTrackColumns()
        {
            var now = DateTime.Now;
            var userIdStr = _accessor?.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString();
            var userId = Guid.Parse(userIdStr);
            foreach (var entry in _context.ChangeTracker.Entries().Where(x => HasTrackColumns(x)))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property(Constant.CreatedDate).CurrentValue = now;
                        entry.Property(Constant.CreatedBy).CurrentValue = userId;
                        break;
                    case EntityState.Modified:
                        entry.Property(Constant.ModifiedDate).CurrentValue = now;
                        entry.Property(Constant.ModifiedBy).CurrentValue = userId;
                        break;
                }
            }
        }

        private bool HasTrackColumns(EntityEntry entry)
        {
            return entry.Properties.Any(x => x.Metadata.Name.Equals(Constant.CreatedBy))
                && entry.Properties.Any(x => x.Metadata.Name.Equals(Constant.CreatedDate))
                && entry.Properties.Any(x => x.Metadata.Name.Equals(Constant.ModifiedBy))
                && entry.Properties.Any(x => x.Metadata.Name.Equals(Constant.ModifiedDate));
        }
    }
}
