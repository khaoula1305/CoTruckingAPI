namespace Cotrucking.Domain.Models.Common
{
    public class ResponseModel<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int Count { get; set; }
    }
}
