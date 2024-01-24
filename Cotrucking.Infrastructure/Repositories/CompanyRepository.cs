using Cotrucking.Domain;
using Cotrucking.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Infrastructure.Repositories
{
    public interface ICompanyRepository : IGenericRepository<CompanyDataModel>
    {
    }

    public  class CompanyRepository : GenericRepository<CompanyDataModel>, ICompanyRepository
    {
        public CompanyRepository(CotruckingDbContext context, IHttpContextAccessor httpContext) : base(context, httpContext) { }
    }
}
