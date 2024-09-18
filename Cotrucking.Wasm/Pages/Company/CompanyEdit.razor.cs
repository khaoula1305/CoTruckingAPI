using Cotrucking.Domain.Models;
using Cotrucking.Wasm.Constant;
using Cotrucking.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Cotrucking.Wasm.Pages.Company
{
    public class CompanyEditBase : ComponentBase
    {
        [Inject]
        public ICompanyService CompanyService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Inject]
        public ILogger<CompanyEditBase> _logger { get; set; }
        [Inject]
        NotificationService NotificationService { get; set; }

        [Parameter]
        public Guid? Id { get; set; }

        public CompanyModel Company { get; set; } = new CompanyModel();

        protected override async Task OnInitializedAsync()
        {

        }

        public override async Task SetParametersAsync(ParameterView Parameters)
        {
            await base.SetParametersAsync(Parameters);
            if (Id != null)
            {
                Company = await CompanyService.GetById(Endpoints.Companies, Id ?? Guid.Empty);
                StateHasChanged();
            }
        }

        public async Task HandleValidSubmitAsync()
        {
            _logger.LogWarning("Create Company");
            await CompanyService.Insert(Endpoints.Companies, Company);
            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Button Clicked", Detail = "text" });

            _navigationManager.NavigateTo("/company");
        }
    }
}