namespace Cotrucking.Domain.Models
{
    public class CityResponse
    {
        public Guid Id { get; set; }
        public string? Label { get; set; }
        public CountryResponse? Country { get; set; }
    }

    public class CityInput
    {
        public Guid? Id { get; set; }
        public string? Label { get; set; }
        public Guid CountryId { get; set; } 
    }

    public class CitySearch
    {
        public int? CountryId { get; set; }
        public int? RegionId { get; set; }
    }

    public class CityExport
    {
        public string? Label { get; set; }
        public CountryResponse? Country { get; set; }
    }
}
