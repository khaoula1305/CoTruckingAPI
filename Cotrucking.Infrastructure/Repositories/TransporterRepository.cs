using Cotrucking.Domain;
using Cotrucking.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories
{
    public interface ITransporterRepository : IGenericRepository<TransporterDataModel>
    {
    }

    public  class TransporterRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) : GenericRepository<TransporterDataModel>(context, httpContext), ITransporterRepository
    {
    }
}
