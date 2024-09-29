using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Cotrucking.Wasm;
using Cotrucking.Wasm.Constant;
using Cotrucking.Wasm.Services;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Serilog;
using Serilog.Extensions.Logging;
using Radzen;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
_ = new Endpoints(builder.Configuration);

var http = new HttpClient()
{
    BaseAddress = new Uri(Endpoints.BaseUrl)
};
builder.Services.AddScoped(sp => http);

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
var levelSwitch = new Serilog.Core.LoggingLevelSwitch();
Log.Logger = new LoggerConfiguration()
    .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
    .WriteTo.BrowserHttp(http)
    .CreateLogger();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Logging.AddProvider(new SerilogLoggerProvider());
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddRadzenComponents();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<ITransporterService, TransporterService>();
builder.Services.AddScoped<IAccountService, AccountService>();

await builder.Build().RunAsync();
