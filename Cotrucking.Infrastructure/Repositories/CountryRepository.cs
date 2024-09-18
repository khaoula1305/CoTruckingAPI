using Cotrucking.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories
{
    public interface ICountryRepository : IGenericRepository<CountryDataModel>
    {
    }

    public  class CountryRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) : GenericRepository<CountryDataModel>(context, httpContext), ICountryRepository
    {
    }
}
