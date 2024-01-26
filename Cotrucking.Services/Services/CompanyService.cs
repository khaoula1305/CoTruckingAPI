using AutoMapper;
using Cotrucking.Domain.Entities;
using Cotrucking.Domain.Models;
using Cotrucking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Services.Services
{
    public interface ICompanyService: IGenericService<CompanyDataModel, CompanyResponse>
    {
    }

    public  class CompanyService(ICompanyRepository companyRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) 
                : GenericService<CompanyDataModel, CompanyResponse>(companyRepository,mapper, httpContextAccessor), ICompanyService
    {
    }
}
