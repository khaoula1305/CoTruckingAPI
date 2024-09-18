namespace Cotrucking.Shared.Models
{
    public class AddressResponse
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Address { get; set; }
        public CityResponse? City { get; set; }
    }

    public class AddressInput
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public Guid CityId { get; set; }
    }

    public class AddressSearch
    {
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
    }

    public class AddressExport
    {
        public string? Name { get; set; }
        public CityResponse? City { get; set; }
    }
}
