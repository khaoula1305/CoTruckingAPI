using Cotrucking.Domain.Models;
using Cotrucking.Domain.Models.Common;
using Cotrucking.Wasm.Constant;
using Cotrucking.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Cotrucking.Wasm.Pages.Company
{
    public class CompanyListBase : ComponentBase
    {
        [Inject]
        public ICompanyService CompanyService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public IEnumerable<CompanyModel> companies = new List<CompanyModel>();
        public RequestModel<CompanySearch> Request = new();
        public ResponseModel<CompanyModel> Response = new();
        public string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        public int pageSize = 6;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Response = await CompanyService.Search(Endpoints.Companies, Request);
            StateHasChanged();
        }

        public async Task PageChanged(PagerEventArgs args)
        {
            Request.Page = args.PageIndex;
            Response = await CompanyService.Search(Endpoints.Companies, Request);
        }

        public void OnNavigateToCompany(Guid id)
        {
            NavigationManager.NavigateTo($"/Company/{id}");
        }

        public void OnAdd()
        {
            NavigationManager.NavigateTo($"/Company/Create");
        }
    }
}