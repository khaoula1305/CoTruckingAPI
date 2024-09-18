namespace Cotrucking.Domain.Models.Common
{
    public class ResponseModel<T> 
    {
        public int Count { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
