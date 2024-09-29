namespace Cotrucking.Domain.Models;


public class ShipmentModel
{
    public Guid? Id { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? DriverId { get; set; }
    public AddressModel? OriginAddress { get; set; } = new AddressModel();
    public Guid OriginAddressId { get; set; }
    public Guid? DestinationAddressId { get; set; }
    public AddressModel? DestinationAddress { get; set; } = new AddressModel();
    public string? CargoDetails { get; set; }
    public DateTime DateTimeOfShipment { get; set; }
    public TimeSpan Duration { get; set; }
    public string? Name { get; set; }
    public string ExpeditionType { get; set; } // GoodsTransport, PeopleTransport
    public string Description { get; set; }
    public VehiculeModel Vehicule { get; set; }
    public Guid VehiculeId { get; set; }

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
