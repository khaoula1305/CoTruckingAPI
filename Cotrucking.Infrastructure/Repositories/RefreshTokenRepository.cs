using Cotrucking.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshTokenDataModel>
    {
    }

    public  class RefreshTokenRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) : GenericRepository<RefreshTokenDataModel>(context, httpContext), IRefreshTokenRepository
    {
    }
}
