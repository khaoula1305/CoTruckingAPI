namespace Cotrucking.Infrastructure.Entities.Security
{
    public class PageFunctionalityDataModel : BaseEntity
    {
        public virtual RoleDataModel Role { get; set; } = new();
        public Guid RoleId { get; set; }
        public virtual PageDataModel Page { get; set; } = new();
        public Guid PageId { get; set; }
        public virtual FunctionalityDataModel Functionality { get; set; } = new();
        public Guid FunctionalityId { get; set; }
    }
}
