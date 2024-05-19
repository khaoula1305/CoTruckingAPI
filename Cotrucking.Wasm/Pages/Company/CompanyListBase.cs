using Cotrucking.Wasm.Constant;
using Microsoft.AspNetCore.Components;

namespace Cotrucking.Wasm.Pages.Company
{
    public class CompanyListBase : ComponentBase
    {
        [Inject]
        public ICompanyService _companyService { get; set; }
        public IEnumerable<CompanyModel> companies = new List<CompanyModel>();

        protected override async Task OnInitializedAsync()
        {
            companies = await _companyService.GetAllAsync(Endpoints.Companies);
            StateHasChanged();
        }
    }
}