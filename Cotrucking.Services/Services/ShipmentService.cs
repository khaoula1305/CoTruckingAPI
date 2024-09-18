using AutoMapper;
using Cotrucking.Infrastructure.Entities;
using Cotrucking.Domain.Models;
using Cotrucking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Cotrucking.Services.Services
{
    public interface IShipmentService: IGenericService<ShipmentDataModel, ShipmentResponse>
    {
    }

    public  class ShipmentService(IShipmentRepository shipmentRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) 
                : GenericService<ShipmentDataModel, ShipmentResponse>(shipmentRepository,mapper, httpContextAccessor), IShipmentService
    {
    }
}
