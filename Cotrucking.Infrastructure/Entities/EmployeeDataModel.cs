namespace Cotrucking.Infrastructure.Entities
{
    public class EmployeeDataModel: BaseEntity
    {
        public Guid CompanyId { get; set; }
        public virtual CompanyDataModel? Company { get; set; }
        public virtual UserDataModel? User { get; set; }
        public Guid UserId { get; set; }
    }
}