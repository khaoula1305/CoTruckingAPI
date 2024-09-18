using Cotrucking.Domain.Models;
namespace Cotrucking.Wasm.Services;

public interface IShipmentService : IGenericService<ShipmentModel, ShipmentSearch>
{
}


public class ShipmentService(HttpClient httpClient) : GenericService<ShipmentModel, ShipmentSearch>(httpClient), IShipmentService
{
}