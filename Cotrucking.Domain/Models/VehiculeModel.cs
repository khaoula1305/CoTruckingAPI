namespace Cotrucking.Domain.Models;
public class VehiculeModel
{
    public int Id { get; set; }
    public string Type { get; set; } // Car, Truck, etc.
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public int Capacity { get; set; }
    public string Status { get; set; } // Available, Rented, In Maintenance, etc.
    public double RentalPrice { get; set; }
    //public VehiculeOwner Owner { get; set; }

    //public List<Schedule> TimePlanning { get; set; }

 
}
