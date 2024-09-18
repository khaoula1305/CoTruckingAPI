namespace Cotrucking.Infrastructure.Entities
{
    public class CompanyDataModel: BaseEntity
    {
        public string? Name { get; set; }
        public string? ContactInformation { get; set; }
        public string? RegistrationNumber { get; set; }
        public virtual AddressDataModel? Address { get; set; }
        public Guid AddressId { get; set; }
        public virtual ICollection<TransporterDataModel> Transporters { get; set; } = new List<TransporterDataModel>();
        public virtual ICollection<VehicleDataModel> Vehicles { get; set; } = new List<VehicleDataModel>();
    }
}