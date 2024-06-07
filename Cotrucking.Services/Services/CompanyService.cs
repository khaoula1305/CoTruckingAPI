using AutoMapper;
using Cotrucking.Domain.Entities;
using Cotrucking.Domain.Models;
using Cotrucking.Infrastructure.Repositories;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Services.Services
{
    public interface ICompanyService : IGenericService<CompanyDataModel, CompanyResponse>
    {
    }

    public class CompanyService(ICompanyRepository companyRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
                : GenericService<CompanyDataModel, CompanyResponse>(companyRepository, mapper, httpContextAccessor), ICompanyService
    {

        public override async Task<CompanyResponse> AddAsync<CompanyInput>(CompanyInput entity)
        {
            var repoEntity = mapper.Map<CompanyDataModel>(entity);
            repoEntity.Address = new()
            {
                City = new CityDataModel()
                {
                    Country = new CountryDataModel() { }
                }
            };
            await companyRepository.InsertAsync(repoEntity);
            await companyRepository.SaveChangesAsync();
            return mapper.Map<CompanyResponse>(repoEntity);
        }
    }
}
