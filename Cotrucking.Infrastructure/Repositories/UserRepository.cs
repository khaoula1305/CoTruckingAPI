using Cotrucking.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories
{
    public interface IUserRepository : IGenericRepository<UserDataModel>
    {
    }

    public class UserRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) : GenericRepository<UserDataModel>(context, httpContext), IUserRepository
    {
    }
}
