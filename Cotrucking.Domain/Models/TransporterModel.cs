using Cotrucking.Domain.Enums;

namespace Cotrucking.Domain.Models;

public class TransporterModel
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public byte[]? Photo { get; set; }
    public string? LicenseNumber { get; set; }
    public AvailabilityStatus? AvailabilityStatus { get; set; }
    public Guid UserId { get; set; }
    public virtual CompanyInput? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public DateTime? HireDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string JobRole { get; set; }
    public decimal Salary { get; set; }
    public virtual UserModel User { get; set; } = new UserModel();
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
    public virtual CompanyResponse? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public DateTime? HireDate { get; set; }
    public virtual UserResponse? User { get; set; }
}

public class TransporterInput
{
    public string? LicenseNumber { get; set; }
    public AvailabilityStatus? AvailabilityStatus { get; set; }
    public Guid? CompanyId { get; set; }
    public string Description { get; set; }
    public byte[]? Photo { get; set; }
    public Guid UserId { get; set; }
    public DateTime? HireDate { get; set; }
    public UserInput? User { get; set; }
}

public class TransporterExport
{
    public string? LicenseNumber { get; set; }
    public AvailabilityStatus? AvailabilityStatus { get; set; }
}

