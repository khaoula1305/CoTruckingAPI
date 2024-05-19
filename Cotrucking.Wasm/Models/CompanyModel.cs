public class CompanyModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ContactInformation { get; set; }
    public string? RegistrationNumber { get; set; }
    // public virtual AddressDataModel? Address { get; set; }
    public Guid AddressId { get; set; }
}