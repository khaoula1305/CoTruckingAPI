namespace Cotrucking.Domain.Models.Common
{
    public class ResponseModel<T>
    {
        public IEnumerable<T> Liste { get; set; } = new List<T>();
        public int TotalCount { get; set; }
    }
}
