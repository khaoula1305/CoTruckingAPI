using Cotrucking.Domain.Models;
using Cotrucking.Wasm.Constant;
using Cotrucking.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using static System.Net.WebRequestMethods;

namespace Cotrucking.Wasm.Pages.Shipment
{
    public class ShipmentEditBase : ComponentBase
    {
        [Inject]
        public IShipmentService ShipmentService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        public ILogger<ShipmentEditBase> _logger { get; set; }
        [Inject]
        NotificationService NotificationService { get; set; }

        [Parameter]
        public Guid? Id { get; set; }
        public ShipmentModel Shipment { get; set; } = new ShipmentModel();

        public List<VehiculeModel> vehicles = new List<VehiculeModel>();
        public List<string> expeditionTypes = new List<string> { "Goods Transport", "People Transport" };

        protected override async Task OnInitializedAsync()
        {
        }

        public override async Task SetParametersAsync(ParameterView Parameters)
        {
            await base.SetParametersAsync(Parameters);
            if (Id != null)
            {
                Shipment = await ShipmentService.GetById(Endpoints.Shipments, Id ?? Guid.Empty);
                StateHasChanged();
            }
        }

        public async Task HandleValidSubmitAsync()
        {
            _logger.LogWarning("Create Shipment");
            await ShipmentService.Insert(Endpoints.Shipments, Shipment);
            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Button Clicked", Detail = "text" });
            _navigationManager.NavigateTo(PageLinks.Shipment);
        }
    }
}