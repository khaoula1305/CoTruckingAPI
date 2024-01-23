namespace Cotrucking.Domain.Entities
{
    public class CustomerDataModel: BaseEntity
    {
        public virtual UserDataModel? User { get; set; }
        public Guid UserId { get; set; }
    }
}
