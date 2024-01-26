namespace Cotrucking.Domain.Models
{
    public class ShipmentResponse
    {
        public string? Name { get; set; }
    }

    public class ShipmentInput
    {
                public string? Name { get; set; }

    }
    
    public class ShipmentSearch
    {
        public int? CountryId { get; set; }
        public int? RegionId { get; set; }
    }

    public class ShipmentExport
    {
    }
}
