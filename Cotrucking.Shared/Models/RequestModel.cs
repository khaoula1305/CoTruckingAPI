//using Radzen;

namespace Cotrucking.Wasm.Models
{
    public class RequestModel<T>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 8;
        public T? Filters { get; set; }
        public Sorting Sorts { get; set; } = new Sorting();
       // public IEnumerable<SortDescriptor>? SortsList { get; set; }
    }



    public class Sorting
    {
        public string? ColumnSort { get; set; }
        public bool? IsDescending { get; set; } = false;
    }
}
