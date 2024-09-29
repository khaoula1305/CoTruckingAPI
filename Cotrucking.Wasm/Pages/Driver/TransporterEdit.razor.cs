using Cotrucking.Domain.Models;
using Cotrucking.Wasm.Constant;
using Cotrucking.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Cotrucking.Wasm.Pages;

public class DriverEditBase : ComponentBase
{
    [Inject]
    public IDriverService DriverService { get; set; }
    [Inject]
    public NavigationManager _navigationManager { get; set; }
    [Inject]
    public ILogger<DriverEditBase> _logger { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }

    [Parameter]
    public Guid? Id { get; set; }

    public Dictionary<int, string> Titles = new Dictionary<int, string>();
    public DriverModel Driver { get; set; } = new DriverModel();

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
            Driver = await DriverService.GetById(Endpoints.Drivers, Id ?? Guid.Empty);
            StateHasChanged();
        }
    }

    public void Submit(DriverModel arg)
    {
        _logger.LogWarning("Create Driver");
        var tras = DriverService.Insert(Endpoints.Drivers, Driver).Result;
        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Button Clicked", Detail = "text" });

        _navigationManager.NavigateTo("/Driver");
    }

    public void Cancel()
    {
        //
    }
}

