using Cotrucking.Wasm.Constant;
using Microsoft.AspNetCore.Components;

namespace Cotrucking.Wasm.Pages.Company
{
    public class CompanyEditBase : ComponentBase
    {
        [Inject]
        public ICompanyService _companyService { get; set; }
        [Parameter]
        public Guid? Id { get; set; }

        public CompanyModel company { get; set; } = new CompanyModel();

        protected override async Task OnInitializedAsync()
        {

        }

        public override async Task SetParametersAsync(ParameterView Parameters)
        {
            await base.SetParametersAsync(Parameters);
            if (Id != null)
            {
                company = await _companyService.GetCompanyById(Endpoints.Companies, Id ?? Guid.Empty);
                StateHasChanged();
            }
        }
    }
}