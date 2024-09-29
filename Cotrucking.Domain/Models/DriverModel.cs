using Cotrucking.Domain.Enums;

namespace Cotrucking.Domain.Models;

public class DriverModel
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

public class DriverSearch
{
    public string? Name { get; set; }
    public Guid? CompanyId { get; set; }
}


public class DriverResponse
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

public class DriverInput
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

public class DriverExport
{
    public string? LicenseNumber { get; set; }
    public AvailabilityStatus? AvailabilityStatus { get; set; }
}

