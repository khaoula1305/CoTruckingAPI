using Cotrucking.Domain.Models;

namespace Cotrucking.Wasm.Services;

public interface IDriverService : IGenericService<DriverModel, DriverSearch>
{
}


public class DriverService(HttpClient httpClient) : GenericService<DriverModel, DriverSearch>(httpClient), IDriverService
{
}
