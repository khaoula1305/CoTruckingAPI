using Cotrucking.Infrastructure.Entities.Security;
using Cotrucking.Infrastructure.Interfaces.Security;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories.Security
{
    public class PageFunctionalityRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) :
        GenericRepository<PageFunctionalityDataModel>(context, httpContext), IPageFunctionalityRepository { }
}
