using Microsoft.AspNetCore.Components;
using Cotrucking.Wasm.Models;

namespace Cotrucking.Wasm.Pages.Account
{
    public class LoginBase : ComponentBase
    {
        public LoginModel login { get; set; } = new();

        public void OnValidSubmit()
        {

        }
    }
}