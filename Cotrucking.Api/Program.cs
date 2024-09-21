using Cotrucking.Api.Extensions;
using Cotrucking.Api.Middlewares;
using Cotrucking.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((hbc, lc) => lc.ReadFrom.Configuration(hbc.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(Constant.CorsName);
app.UseSerilogIngestion();
app.UseSerilogRequestLogging();
app.MapHealthChecks(Constant.HealthEnpoint);
app.UseHttpsRedirection();
// auth
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();

app.UseHsts();

app.Run();
