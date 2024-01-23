namespace Cotrucking.Domain.Entities
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
        public virtual UserDataModel? Customer { get; set; }
        public virtual ICollection<ApplicationDataModel>? Applications { get; set; }
        public int CustomerId { get; set; }

    }
}