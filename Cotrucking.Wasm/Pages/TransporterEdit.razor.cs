using Cotrucking.Wasm.Constant;
using Cotrucking.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Cotrucking.Wasm.Pages;

public class TransporterEditBase : ComponentBase
{
    [Inject]
    public ITransporterService TransporterService { get; set; }
    [Inject]
    public NavigationManager _navigationManager { get; set; }
    [Inject]
    public ILogger<TransporterEditBase> _logger { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }

    [Parameter]
    public Guid? Id { get; set; }

    public TransporterModel Transporter { get; set; } = new TransporterModel()
    {
        HireDate =  DateTime.Now
    };

    protected override async Task OnInitializedAsync()
    {

    }

    public override async Task SetParametersAsync(ParameterView Parameters)
    {
        await base.SetParametersAsync(Parameters);
        if (Id != null)
        {
            Transporter = await TransporterService.GetById(Endpoints.Transporters, Id ?? Guid.Empty);
            StateHasChanged();
        }
    }

    public async Task Submit(TransporterModel arg)
    {
        _logger.LogWarning("Create Transporter");
        await TransporterService.Insert(Endpoints.Transporters, Transporter);
        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Button Clicked", Detail = "text" });

        _navigationManager.NavigateTo("/Transporter");
    }

    public void Cancel()
    {
        //
    }
}

