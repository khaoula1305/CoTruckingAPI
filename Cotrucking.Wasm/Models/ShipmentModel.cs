namespace Cotrucking.Wasm.Models;
public class ShipmentModel
{
        public Guid? CustomerId { get; set; }
        public Guid? TransporterId { get; set; }
        public Guid OriginAddressId { get; set; }
        public Guid? DestinationAddressId { get; set; }
        public string? CargoDetails { get; set; }
        public DateTime DateTimeOfShipment { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Name { get; set; }
}
