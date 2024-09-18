namespace Cotrucking.Infrastructure.Entities
{
    public class CustomerDataModel: BaseEntity
    {
        public virtual UserDataModel? User { get; set; }
        public Guid UserId { get; set; }
    }
}
