namespace Cotrucking.Wasm.Models;
public class ShipmentModel
{
        public virtual CustomerModel? Customer {  get; set; } 
        public Guid? CustomerId { get; set; }
        public virtual TransporterModel? Transporter { get; set; } = new TransporterModel();
        public Guid? TransporterId { get; set; }
        public virtual AddressModel OriginAddress { get; set; } = new AddressModel();
        public Guid OriginAddressId { get; set; }
        public virtual AddressModel? DestinationAddress { get; set; }   
        public Guid? DestinationAddressId { get; set; }
        public string? CargoDetails { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime DateTimeOfShipment { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Name { get; set; }
}
