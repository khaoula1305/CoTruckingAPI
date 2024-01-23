using Cotrucking.Domain.Enums;

namespace Cotrucking.Domain.Entities
{
    public class ShipmentDataModel: BaseEntity
    {
        public virtual CustomerDataModel? Customer {  get; set; } 
        public Guid? CustomerId { get; set; }
        public virtual TransporterDataModel? Transporter { get; set; } = new TransporterDataModel();
        public Guid? TransporterId { get; set; }
        public virtual AddressDataModel OriginAddress { get; set; } = new AddressDataModel();
        public Guid OriginAddressId { get; set; }
        public virtual AddressDataModel? DestinationAddress { get; set; }   
        public Guid? DestinationAddressId { get; set; }
        public string? CargoDetails { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime DateTimeOfShipment { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Label { get; set; }
    }
}
