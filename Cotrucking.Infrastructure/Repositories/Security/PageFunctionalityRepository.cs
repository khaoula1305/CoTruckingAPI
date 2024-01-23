using Cotrucking.Domain.Entities.Security;
using Cotrucking.Domain.Interfaces.Security;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories.Security
{
    public class PageFunctionalityRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) :
        GenericRepository<PageFunctionalityDataModel>(context, httpContext), IPageFunctionalityRepository { }
}
