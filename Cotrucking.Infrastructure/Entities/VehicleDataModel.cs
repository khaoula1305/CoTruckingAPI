namespace Cotrucking.Infrastructure.Entities
{
    public class VehicleDataModel : BaseEntity
    {
        public string? VehicleType { get; set; }
        public string? LicensePlate { get; set; }
        public string? VehicleCapacity { get; set; }
        public DateTime MaintenanceSchedule { get; set; }
        public virtual CompanyDataModel? Company { get; set; }
        public Guid? CompanyId { get; set; }
    }
}