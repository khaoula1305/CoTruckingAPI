using Cotrucking.Wasm.Models;
namespace Cotrucking.Wasm.Services;

public interface ICompanyService : IGenericService<CompanyModel, CompanySearch>
{
}


public class CompanyService(HttpClient httpClient) : GenericService<CompanyModel, CompanySearch>(httpClient), ICompanyService
{
}