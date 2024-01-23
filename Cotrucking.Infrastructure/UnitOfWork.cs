using Cotrucking.Domain.Interfaces;
using Cotrucking.Domain.Interfaces.Security;
using Cotrucking.Infrastructure.Repositories.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;

namespace Cotrucking.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CotruckingDbContext _context;
        public IPageFunctionalityRepository PageFunctinalities { get; private set; }

        private readonly IHttpContextAccessor _accessor;

        public UnitOfWork(CotruckingDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _accessor = httpContext;
            PageFunctinalities = new PageFunctionalityRepository(_context, _accessor);
        }
        public async Task CompleteAsync()
        {
            using var dbContextTransaction = await _context.Database.BeginTransactionAsync();

            try
            {
                SetAuditColumns();
                await _context.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }

        private void SetAuditColumns()
        {
            var now = DateTime.Now;
            var userIdStr = _accessor?.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";
            var userId = long.Parse(userIdStr);

            var addedEntries = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            foreach (var entry in addedEntries.Where(x => HasAuditColumns(x)))
            {
                entry.Property("CreatedDate").CurrentValue = now;
                entry.Property("CreatedBy").CurrentValue = userId;
            }

            var modifiedEntries = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            foreach (var entry in modifiedEntries.Where(x => HasAuditColumns(x)))
            {
                entry.Property("DateAjout").IsModified = false;
                entry.Property("AjoutePar").IsModified = false;
                entry.Property("ModifiedDate").CurrentValue = now;
                entry.Property("ModifiedBy").CurrentValue = userId;
            }
        }

        private bool HasAuditColumns(EntityEntry entry)
        {
            return entry.Properties.Any(x => x.Metadata.Name.Equals("CreatedDate"))
                && entry.Properties.Any(x => x.Metadata.Name.Equals("CreatedBy"))
                && entry.Properties.Any(x => x.Metadata.Name.Equals("ModifiedBy"))
                && entry.Properties.Any(x => x.Metadata.Name.Equals("ModifiedDate"));
        }
    }
}
