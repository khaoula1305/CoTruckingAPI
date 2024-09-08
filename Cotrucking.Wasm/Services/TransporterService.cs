namespace Cotrucking.Wasm.Services;

public interface ITransporterService : IGenericService<TransporterModel, TransporterSearch>
{
}


public class TransporterService(HttpClient httpClient) : GenericService<TransporterModel, TransporterSearch>(httpClient), ITransporterService
{
}
