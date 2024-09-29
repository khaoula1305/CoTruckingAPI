namespace Cotrucking.Infrastructure.Entities
{
    public class ApplicationDataModel : BaseEntity
    {
        public Guid RequestId { get; set; }
        public virtual RequestDataModel Request { get; set; }
        public Guid DriverId { get; set; }
        public virtual DriverDataModel Driver { get; set; }
    }
}