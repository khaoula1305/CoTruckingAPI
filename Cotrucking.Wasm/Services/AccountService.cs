using Cotrucking.Wasm.Models;
namespace Cotrucking.Wasm.Services;

public interface IAccountService : IGenericService<LoginModel>
{
}


public class AccountService : GenericService<LoginModel>, IAccountService
{

    public AccountService(HttpClient httpClient) : base(httpClient)
    {

    }
}