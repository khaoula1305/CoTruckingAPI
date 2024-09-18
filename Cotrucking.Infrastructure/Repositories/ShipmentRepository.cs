using Cotrucking.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories
{
    public interface IShipmentRepository : IGenericRepository<ShipmentDataModel>
    {
    }

    public  class ShipmentRepository : GenericRepository<ShipmentDataModel>, IShipmentRepository
    {
        public ShipmentRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) : base(context, httpContext) { }
    }
}
