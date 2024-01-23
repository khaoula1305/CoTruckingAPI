using Cotrucking.Domain.Enums;

namespace Cotrucking.Domain.Entities;
public class TransporterDataModel: BaseEntity
{
    public string? LicenseNumber { get; set; }
    public AvailabilityStatus? AvailabilityStatus { get; set; }
    public virtual UserDataModel? User { get; set; }
    public Guid UserId { get; set; }
    public virtual CompanyDataModel? Company { get; set; }
    public Guid? CompanyId { get; set; }
    //public ICollection<ShipmentDataModel>? Shipments { get; set; }
    //public ICollection<ApplicationDataModel>? Applications { get; set; }
}