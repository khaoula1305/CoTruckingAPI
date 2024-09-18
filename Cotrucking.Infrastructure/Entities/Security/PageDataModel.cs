namespace Cotrucking.Infrastructure.Entities.Security
{
    public class PageDataModel : BaseEntity
    {
        public string? Label { get; set; }
        public virtual ICollection<PageFunctionalityDataModel>? PageFunctionalities { get; set; }
    }
}