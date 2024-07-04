using Cotrucking.Wasm.Models;
namespace Cotrucking.Wasm.Services;

public interface IShipmentService : IGenericService<ShipmentModel, ShipmentModel>
{
}


public class ShipmentService(HttpClient httpClient) : GenericService<ShipmentModel, ShipmentModel>(httpClient), IShipmentService
{
}