namespace Cotrucking.Domain.Entities
{
    public class AddressDataModel : BaseEntity
    {
        public virtual CityDataModel? City { get; set; }
        public Guid CityId { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Address { get; set; }
    }
}
