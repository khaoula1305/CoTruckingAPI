namespace Cotrucking.Infrastructure.Entities
{
    public class ApplicationDataModel : BaseEntity
    {
        public Guid RequestId { get; set; }
        public virtual RequestDataModel Request { get; set; }
        public Guid TransporterId { get; set; }
        public virtual TransporterDataModel Transporter { get; set; }
    }
}