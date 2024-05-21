using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Cotrucking.Wasm;
using Cotrucking.Wasm.Constant;
using Cotrucking.Wasm.Services;
using Serilog;
using Serilog.Extensions.Logging;

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

builder.Logging.AddProvider(new SerilogLoggerProvider());
builder.Services.AddScoped<ICompanyService, CompanyService>();

await builder.Build().RunAsync();
