using Cotrucking.Domain.Enums;

namespace Cotrucking.Infrastructure.Entities
{
    public class ShipmentDataModel: BaseEntity
    {
        public virtual DriverDataModel? Driver { get; set; } = new DriverDataModel();
        public Guid? DriverId { get; set; }
        public virtual AddressDataModel OriginAddress { get; set; } = new AddressDataModel();
        public Guid OriginAddressId { get; set; }
        public virtual AddressDataModel? DestinationAddress { get; set; }   
        public Guid? DestinationAddressId { get; set; }
        public string? CargoDetails { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime DateTimeOfShipment { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Name { get; set; }
        public string? ExpeditionType { get; set; } // GoodsTransport, PeopleTransport
        //ToBeModified  should have many customers
        public virtual CustomerDataModel? Customer { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
