namespace Cotrucking.Infrastructure.Entities
{
    public class CompanyDataModel: BaseEntity
    {
        public string? Name { get; set; }
        public string? ContactInformation { get; set; }
        public string? RegistrationNumber { get; set; }
        public virtual AddressDataModel? Address { get; set; }
        public Guid AddressId { get; set; }
        public virtual ICollection<DriverDataModel>? Drivers { get; set; }
        public virtual ICollection<VehiculeDataModel>? Vehicules { get; set; }
        public virtual ICollection<EmployeeDataModel>? Employees { get; set; }
    }
}