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

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
var levelSwitch = new Serilog.Core.LoggingLevelSwitch();
Log.Logger = new LoggerConfiguration()
    .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
    .WriteTo.BrowserHttp(http)
    .CreateLogger();

builder.Logging.AddProvider(new SerilogLoggerProvider());
builder.Services.AddScoped<ICompanyService, CompanyService>();

_ = new Endpoints(builder.Configuration);
await builder.Build().RunAsync();
