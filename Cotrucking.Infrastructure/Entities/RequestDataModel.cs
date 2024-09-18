namespace Cotrucking.Infrastructure.Entities
{
    public class RequestDataModel : BaseEntity
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? CargoDetails { get; set; }
        public DateTime PreferredTransportDateTime { get; set; }
        public string? Status { get; set; }
        public int SelectedTransporterId { get; set; }
        public DateTime ResponseDeadline { get; set; }
        //public virtual CustomerDataModel? Customer { get; set; }
        //public int CustomerId { get; set; }
        public virtual ICollection<ApplicationDataModel>? Applications { get; set; }
    }
}