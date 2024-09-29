using Cotrucking.Domain;
using Cotrucking.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories
{
    public interface IDriverRepository : IGenericRepository<DriverDataModel>
    {
    }

    public  class DriverRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) : GenericRepository<DriverDataModel>(context, httpContext), IDriverRepository
    {
    }
}
