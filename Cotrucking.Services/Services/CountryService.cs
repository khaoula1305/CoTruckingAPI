using AutoMapper;
using Cotrucking.Infrastructure.Entities;
using Cotrucking.Domain.Models;
using Cotrucking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Services.Services
{
    public interface ICountryService : IGenericService<CountryDataModel, CountryResponse>
    {
    }

    public  class CountryService(ICountryRepository countryRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericService<CountryDataModel, CountryResponse>(countryRepository, mapper, httpContextAccessor), ICountryService
    {
    }
}
