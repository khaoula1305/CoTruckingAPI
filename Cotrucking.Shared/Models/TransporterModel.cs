using Cotrucking.Shared.Enums;
using Cotrucking.Wasm.Models;

namespace Cotrucking.Shared.Models;

public class TransporterModel
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
    public Guid? CompanyId { get; set; }
}


public class TransporterResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public byte[]? Photo { get; set; }
    public string? LicenseNumber { get; set; }
    public AvailabilityStatus? AvailabilityStatus { get; set; }
    public Guid UserId { get; set; }
    public CompanyModel? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public DateTime? HireDate { get; set; }
    public UserModel? User { get; set; }
}

public class TransporterInput
{
    public string? LicenseNumber { get; set; }
    public AvailabilityStatus? AvailabilityStatus { get; set; }
    public Guid? CompanyId { get; set; }
}

public class TransporterExport
{
    public string? LicenseNumber { get; set; }
    public AvailabilityStatus? AvailabilityStatus { get; set; }
}

