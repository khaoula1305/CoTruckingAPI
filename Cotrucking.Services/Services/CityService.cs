using AutoMapper;
using Cotrucking.Domain.Entities;
using Cotrucking.Domain.Models;
using Cotrucking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Services.Services
{
    public interface ICityService : IGenericService<CityDataModel, CityResponse>
    {
    }

    public  class CityService(ICityRepository cityRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericService<CityDataModel, CityResponse>(cityRepository,mapper,httpContextAccessor), ICityService
    {
    }
}
