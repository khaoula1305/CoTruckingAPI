using Cotrucking.Wasm.Constant;
using Cotrucking.Domain.Models;
using Cotrucking.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using Cotrucking.Domain.Models.Common;

namespace Cotrucking.Wasm.Pages;

public class DriverListBase : ComponentBase
{
    [Inject]
    public IDriverService DriverService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public IEnumerable<DriverModel> transporters = new List<DriverModel>();
    public RequestModel<DriverSearch> Request = new();
    public ResponseModel<DriverModel> Response = new();
    public string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
    public int pageSize = 6;
    //What i need
    public RadzenDataGrid<DriverModel> grid;
    public int count;
    public IEnumerable<DriverModel> Drivers;
    public bool isLoading = false;
    public List<string> titles = new List<string> { "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator" };
    public IEnumerable<string> selectedTitles;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Response = await DriverService.Search(Endpoints.Drivers, Request);
        StateHasChanged();
    }

    public async Task LoadData(LoadDataArgs args)
    {
        isLoading = true;
        Console.WriteLine(args.Filter);


        if (!string.IsNullOrEmpty(args.OrderBy))
        {
            // Sort via the OrderBy method
            //query = query.OrderBy(args.OrderBy);
            //Request.Sorts.ColumnSort = args.OrderBy;
            //Request.SortsList = args.Sorts;
        }
        // Perform paging via Skip and Take.
        Request.PageSize = args.Top.Value;
        Request.Page = args.Skip.Value / args.Top.Value +1;

        // Important!!! Make sure the Count property of RadzenDataGrid is set.
        Response = await DriverService.Search(Endpoints.Drivers, Request);
        count = Response.Count;
        Drivers = Response.Items;
        isLoading = false;
    }

    public async Task PageChanged(PagerEventArgs args)
    {
        Request.Page = args.PageIndex;
        Response = await DriverService.Search(Endpoints.Drivers, Request);
    }

    public void OnNavigateToDriver(Guid id)
    {
        NavigationManager.NavigateTo($"/Driver/{id}");
    }

    public void OnAdd()
    {
        NavigationManager.NavigateTo($"/Driver/Create");
    }


    async Task OnSelectedTitlesChange(object value)
    {
        if (selectedTitles != null && !selectedTitles.Any())
        {
            selectedTitles = null;
        }

        await grid.FirstPage();
    }

    public async Task Reset()
    {
        grid.Reset(true);
        await grid.FirstPage(true);
    }

   
}
