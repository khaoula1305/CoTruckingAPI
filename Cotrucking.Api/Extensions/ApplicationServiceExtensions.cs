using Asp.Versioning;
using Cotrucking.Domain.Constants;
using Cotrucking.Domain.Extensions;
using Cotrucking.Infrastructure;
using Cotrucking.Infrastructure.Entities;
using Cotrucking.Infrastructure.Interfaces.Security;
using Cotrucking.Infrastructure.Repositories;
using Cotrucking.Infrastructure.Repositories.Security;
using Cotrucking.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Jwt.Secret)),
                ValidateIssuer = true,
                ValidIssuer = appSettings.Jwt.Issuer,
                ValidateAudience = true,
                ValidAudience = appSettings.Jwt.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddSingleton(tokenValidationParameters);
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
            // Or Add Authentication
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
                .AddJwtBearer(options =>
                {
                    // Mecanisme that will be used to validate token
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false; // allow http as well
                    options.TokenValidationParameters = tokenValidationParameters;
                });


            services.AddAuthorizationBuilder();

            // Add identity
            services.AddIdentity<UserDataModel, RoleDataModel>()
            .AddEntityFrameworkStores<CotruckingDbContext>()
            .AddDefaultTokenProviders();

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
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            #endregion

            #region services
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUserService, UserService>();
            #endregion
        }
    }
}
