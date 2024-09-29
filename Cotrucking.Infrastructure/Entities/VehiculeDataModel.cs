namespace Cotrucking.Infrastructure.Entities
{
    public class VehiculeDataModel : BaseEntity
    {
        public string? VehicleType { get; set; }
        public string? LicensePlate { get; set; }
        public string? VehicleCapacity { get; set; }
        public DateTime MaintenanceSchedule { get; set; }
        public virtual DriverDataModel? Driver { get; set; }
        public Guid? DriverId { get; set; }
        public virtual CompanyDataModel? Company { get; set; }
        public Guid? CompanyId { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; } // Available, Rented, In Maintenance, etc.
        public double RentalPrice { get; set; }
        public virtual ICollection<AssignmentDataModel>? Assignment { get; set; }
    }
}