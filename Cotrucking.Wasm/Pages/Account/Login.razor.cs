using Microsoft.AspNetCore.Components;
using Cotrucking.Domain.Models;
using Cotrucking.Wasm.Services;

namespace Cotrucking.Wasm.Pages.Account
{
    public class LoginBase : ComponentBase
    {
        public LoginModel login { get; set; } = new();
        [Inject]
        public IAccountService  accountService { get; set; }
        public void OnValidSubmit()
        {
            accountService.Login(login);
        }

    }
}