namespace Cotrucking.Domain.Entities
{
    public class CityDataModel : BaseEntity
    {
        public string? Label { get; set; }
        public virtual CountryDataModel? Country { get; set; }
        public Guid CountryId { get; set; } 
    }
}
