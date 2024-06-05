using Cotrucking.Wasm.Constant;
using Microsoft.AspNetCore.Components;
using Cotrucking.Wasm.Services;
using Cotrucking.Wasm.Models;
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
        public string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        public int pageSize = 6;
        public int count;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            companies = await CompanyService.GetAllAsync(Endpoints.Companies);
            StateHasChanged();
        }

        public async Task PageChanged(PagerEventArgs args)
        {
            companies = await CompanyService.GetAllAsync(Endpoints.Companies);
        }

        public void NavigateToCompany(Guid id)
        {
            NavigationManager.NavigateTo($"/Company/{id}");
        }
    }
}