namespace Cotrucking.Infrastructure.Entities
{
    public class RentalDataModel : BaseEntity
    {
        public virtual VehiculeDataModel? Vehicule { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public double RentalPrice { get; set; }
        public string? Status { get; set; } // Reserved, InProgress, Completed, Cancelled
    }
}
