using Asp.Versioning;
using Cotrucking.Domain.Constants;
using Cotrucking.Domain.Extensions;
using Cotrucking.Domain.Interfaces.Security;
using Cotrucking.Infrastructure;
using Cotrucking.Infrastructure.Repositories;
using Cotrucking.Infrastructure.Repositories.Security;
using Cotrucking.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
namespace Cotrucking.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            var appSettings = configuration.Get<AppSettings>() ?? new AppSettings();

            services.AddDbContext<CotruckingDbContext>(options =>
            {
                options.UseSqlServer(appSettings.ConnectionStrings.CotruckingDb);
                options.UseLazyLoadingProxies();
            });
            services.AddAutoMapper(typeof(Program));
            services.AddLogging(options =>
            {
                options.ClearProviders();
                _ = options.AddLog4Net(appSettings.LogConfigFile);
            });

            // Add services to the container.
            services.AddCors(p => p.AddPolicy(name: Constant.CorsName, builder =>
            {
                builder.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials();
            }));


            //authentification Middlewear
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettings.TokenKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddHealthChecks()
                .AddSqlServer(connectionString: appSettings.ConnectionStrings.CotruckingDb,
                failureStatus: HealthStatus.Degraded)
                .AddCheck<CustomHealthCheck>("My Custom Health Check");

            //API Versioning
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });
            services.AddSingleton<AppSettings>();
            services.AddHttpContextAccessor();
            ConfigureScopedServices(services);

            return services;
        }


        private static void ConfigureScopedServices(IServiceCollection services)
        {
            #region
            services.AddScoped<IPageFunctionalityRepository, PageFunctionalityRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IShipmentRepository, ShipmentRepository>();
            services.AddScoped<ITransporterRepository, TransporterRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            #endregion

            #region services
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<ITransporterService, TransporterService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICompanyService, CompanyService>();
            #endregion
        }
    }
}
