using AutoMapper;
using Cotrucking.Infrastructure.Entities;
using Cotrucking.Domain.Models;
using Cotrucking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Services.Services
{
    public interface IAddressService : IGenericService<AddressDataModel, AddressResponse>
    {
    }

    public class AddressService(IAddressRepository cityRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericService<AddressDataModel, AddressResponse>(cityRepository, mapper, httpContextAccessor), IAddressService
    {
    }
}
