using Microsoft.AspNetCore.Components;

namespace Cotrucking.Wasm.Layout
{
    public class NavMenuBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }

    }
}
