namespace Cotrucking.Domain.Models;


public class ShipmentModel
{
    public Guid? Id { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? TransporterId { get; set; }
    public AddressModel? OriginAddress { get; set; }
    public Guid OriginAddressId { get; set; }
    public Guid? DestinationAddressId { get; set; }
    public AddressModel? DestinationAddress { get; set; }
    public string? CargoDetails { get; set; }
    public DateTime DateTimeOfShipment { get; set; }
    public TimeSpan Duration { get; set; }
    public string? Name { get; set; }
}


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
