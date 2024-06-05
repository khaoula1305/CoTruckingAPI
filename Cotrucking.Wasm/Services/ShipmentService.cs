using Cotrucking.Wasm.Models;
namespace Cotrucking.Wasm.Services;

public interface IShipmentService : IGenericService<ShipmentModel>
{
}


public class ShipmentService : GenericService<ShipmentModel>, IShipmentService
{

    public ShipmentService(HttpClient httpClient) : base(httpClient)
    {

    }
}