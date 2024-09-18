using Cotrucking.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories
{
    public interface ICityRepository : IGenericRepository<CityDataModel>
    {
    }

    public  class CityRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) : GenericRepository<CityDataModel>(context, httpContext), ICityRepository
    {
    }
}
