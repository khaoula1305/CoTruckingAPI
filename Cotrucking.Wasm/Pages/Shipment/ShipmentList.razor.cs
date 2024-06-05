using Cotrucking.Wasm.Constant;
using Microsoft.AspNetCore.Components;
using Cotrucking.Wasm.Services;
using Cotrucking.Wasm.Models;

namespace Cotrucking.Wasm.Pages.Shipement
{
    public class ShipmentListBase : ComponentBase
    {
        [Inject]
        public IShipmentService ShipmentService { get; set; }
        public IEnumerable<ShipmentModel> shipments = new List<ShipmentModel>();

        protected override async Task OnInitializedAsync()
        {
            shipments = await ShipmentService.GetAllAsync(Endpoints.Shipments);
            StateHasChanged();
        }
    }
}