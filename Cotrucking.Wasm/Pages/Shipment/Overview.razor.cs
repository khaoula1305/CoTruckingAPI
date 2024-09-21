using Microsoft.AspNetCore.Components;

namespace Cotrucking.Wasm.Pages.Shipment
{
    public class OverviewBase : ComponentBase
    {
        [Inject]
        public  NavigationManager Navigation {  get; set; }

    }
}
