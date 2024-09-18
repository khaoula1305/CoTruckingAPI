using Cotrucking.Domain.Models;
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

    public Dictionary<int, string> Titles = new Dictionary<int, string>();
    public TransporterModel Transporter { get; set; } = new TransporterModel();

    protected override async Task OnInitializedAsync()
    {
        foreach (var title in Enum.GetValues(typeof(Title)))
        {
            Titles.Add((int)title, title.ToString());
        }
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

    public void Submit(TransporterModel arg)
    {
        _logger.LogWarning("Create Transporter");
        var tras = TransporterService.Insert(Endpoints.Transporters, Transporter).Result;
        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Button Clicked", Detail = "text" });

        _navigationManager.NavigateTo("/Transporter");
    }

    public void Cancel()
    {
        //
    }
}

