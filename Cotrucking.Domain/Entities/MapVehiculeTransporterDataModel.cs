namespace Cotrucking.Domain.Entities
{
    public class MapVehiculeTransporterDataModel : BaseEntity
    {
        public VehicleDataModel? Vehicle { get; set; }
        public Guid VehicleId { get; set; }
        public TransporterDataModel? Transporter { get; set; }
        public Guid? TransporterId { get; set; }
    }
}
