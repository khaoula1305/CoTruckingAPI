namespace Cotrucking.Shared.Models.Common
{
    public class Sort
    {
        //
        // Summary:
        //     Gets or sets the property to sort by.
        //
        // Value:
        //     The property.
        public string Property { get; set; }

        //
        // Summary:
        //     Gets or sets the sort order.
        //
        // Value:
        //     The sort order.
        public SortOrder? SortOrder { get; set; }
    }
}
