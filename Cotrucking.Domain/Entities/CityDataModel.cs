namespace Cotrucking.Domain.Entities
{
    public class CityDataModel : BaseEntity
    {
        public string? Name { get; set; }
        public virtual CountryDataModel? Country { get; set; }
        public Guid CountryId { get; set; } 
    }
}
