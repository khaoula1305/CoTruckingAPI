using Cotrucking.Domain.Enums;

namespace Cotrucking.Infrastructure.Entities;
public class DriverDataModel: BaseEntity
{
    public string? Description { get; set; }
    public decimal? Salary { get; set; }
    public byte[]? PhotoPath { get; set; }
    public string? LicenseNumber { get; set; }
    public AvailabilityStatus? AvailabilityStatus { get; set; }
    public virtual UserDataModel? User { get; set; }
    public Guid UserId { get; set; }
    public virtual CompanyDataModel? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public DateTime? HireDate { get; set; }
    public virtual ICollection<ShipmentDataModel>? Shipments { get; set; }
    public virtual ICollection<ApplicationDataModel>? Applications { get; set; }
    public virtual ICollection<VehiculeDataModel>? AssignedVehicules { get; set; }
}