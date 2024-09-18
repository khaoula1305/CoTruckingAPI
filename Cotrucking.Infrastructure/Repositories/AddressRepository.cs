using Cotrucking.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories
{
    public interface IAddressRepository : IGenericRepository<AddressDataModel>
    {
    }

    public class AddressRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) : GenericRepository<AddressDataModel>(context, httpContext), IAddressRepository
    {
    }
}
