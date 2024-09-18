namespace Cotrucking.Wasm.Models
{
    public class AddressModel
    {
        public CityModel? City { get; set; }
        public Guid CityId { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Address { get; set; }
    }
}