namespace Cotrucking.Domain.Entities
{
    public class MapCompanyShipementDataModel : BaseEntity
    {
        public CompanyDataModel Company { get; set; } = new();
        public Guid CompanyId { get; set; }
        public ShipmentDataModel Shipment { get; set; } = new();
        public Guid ShipementId { get; set; }
        public TransporterDataModel Transporter { get; set; } = new();
        public Guid TransporterId { get; set; }
    }
}
