using Cotrucking.Wasm.Constant;
using Microsoft.AspNetCore.Components;
using Cotrucking.Wasm.Services;
using Cotrucking.Domain.Models;
using Cotrucking.Domain.Models.Common;
using Radzen;

namespace Cotrucking.Wasm.Pages.Shipment
{
    public class ShipmentListBase : ComponentBase
    {
        [Inject]
        public IShipmentService ShipmentService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public RequestModel<ShipmentSearch> Request = new();
        public ResponseModel<ShipmentModel> Response = new();
        public string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        public int pageSize = 6;
        public IEnumerable<ShipmentModel> shipments = new List<ShipmentModel>();

        protected override async Task OnInitializedAsync()
        {
            shipments = await ShipmentService.GetAllAsync(Endpoints.Shipments);
            StateHasChanged();
        }

        public async Task PageChanged(PagerEventArgs args)
        {
            Request.Page = args.PageIndex;
            Response = await ShipmentService.Search(Endpoints.Companies, Request);
        }

        public void OnNavigateToShipment(Guid id)
        {
            NavigationManager.NavigateTo($"/Shipment/{id}");
        }

        public void OnAdd()
        {
            NavigationManager.NavigateTo($"/Shipment/Create");
        }

        public void OnFilter()
        {
            NavigationManager.NavigateTo($"/Shipment/Create");
        }
    }
}