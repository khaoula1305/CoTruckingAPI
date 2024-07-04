namespace Cotrucking.Wasm.Models;
public class CompanyModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Photo { get; set; }
    public string? ContactInformation { get; set; }
    public string? RegistrationNumber { get; set; }
    public AddressModel? Address { get; set; }
    public Guid AddressId { get; set; }
    public decimal Price { get; set; }
}

public class CompanySearch
{
    public string? Name { get; set; }
}
