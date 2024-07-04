namespace Cotrucking.Wasm.Models
{
    public class ResponseModel<T> where T : new()
    {
        public int Count { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
