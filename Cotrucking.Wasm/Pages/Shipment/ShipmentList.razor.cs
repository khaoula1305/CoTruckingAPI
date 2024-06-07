using Cotrucking.Wasm.Constant;
using Microsoft.AspNetCore.Components;
using Cotrucking.Wasm.Services;
using Cotrucking.Wasm.Models;

namespace Cotrucking.Wasm.Pages.Shipment
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

        public List<Hotel> Hotels = new List<Hotel>
{
new Hotel { Name = "Baga Comfort", Location = "New York", Price = 455, Rating = 4.5, ImageUrl =
"https://source.unsplash.com/random/300×300" },
new Hotel { Name = "New Apollo Hotel", Location = "California", Price = 585, Rating = 4.8, ImageUrl =
"https://source.unsplash.com/random/300×300" },
new Hotel { Name = "New Age Hotel", Location = "Los Angeles", Price = 385, Rating = 4.6, ImageUrl =
"https://source.unsplash.com/random/300×300" },
new Hotel { Name = "Helios Beach Resort", Location = "Chicago", Price = 665, Rating = 4.8, ImageUrl =
"https://source.unsplash.com/random/300×300" }
};

        public class Hotel
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public double Price { get; set; }
            public double Rating { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}