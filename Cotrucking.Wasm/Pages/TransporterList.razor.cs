using Cotrucking.Wasm.Constant;
using Cotrucking.Domain.Models;
using Cotrucking.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using Cotrucking.Domain.Models.Common;

namespace Cotrucking.Wasm.Pages;

public class TransporterListBase : ComponentBase
{
    [Inject]
    public ITransporterService TransporterService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public IEnumerable<TransporterModel> transporters = new List<TransporterModel>();
    public RequestModel<TransporterSearch> Request = new();
    public ResponseModel<TransporterModel> Response = new();
    public string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
    public int pageSize = 6;
    //What i need
    public RadzenDataGrid<TransporterModel> grid;
    public int count;
    public IEnumerable<TransporterModel> Transporters;
    public bool isLoading = false;
    public List<string> titles = new List<string> { "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator" };
    public IEnumerable<string> selectedTitles;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Response = await TransporterService.Search(Endpoints.Transporters, Request);
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
        Response = await TransporterService.Search(Endpoints.Transporters, Request);
        count = Response.Count;
        Transporters = Response.Items;
        isLoading = false;
    }

    public async Task PageChanged(PagerEventArgs args)
    {
        Request.Page = args.PageIndex;
        Response = await TransporterService.Search(Endpoints.Transporters, Request);
    }

    public void OnNavigateToTransporter(Guid id)
    {
        NavigationManager.NavigateTo($"/Transporter/{id}");
    }

    public void OnAdd()
    {
        NavigationManager.NavigateTo($"/Transporter/Create");
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
