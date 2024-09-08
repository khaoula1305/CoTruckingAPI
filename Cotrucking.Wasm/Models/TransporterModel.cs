using Cotrucking.Domain.Enums;
using Cotrucking.Wasm.Models;

public class TransporterModel: UserModel
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public byte[]? Photo { get; set; }
    public string? LicenseNumber { get; set; }
    public AvailabilityStatus? AvailabilityStatus { get; set; }
    public Guid UserId { get; set; }
    public virtual CompanyModel? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public DateTime? HireDate { get; set; }
}

public class TransporterSearch
{
    public string? Name { get; set; }
}
