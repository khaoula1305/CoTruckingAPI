namespace Cotrucking.Infrastructure.Entities
{
    public class ShipmentDetailDataModel : BaseEntity
    {
        public Guid ShipmentId { get; set; }
        public virtual ShipmentDataModel Shipment { get; set; } = new ();
    }
}
