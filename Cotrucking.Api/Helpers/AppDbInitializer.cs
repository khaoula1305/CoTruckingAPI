using Cotrucking.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Cotrucking.Api.Helpers
{
    public class AppDbInitializer
    {
        public static async Task SeedRolesToDb(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<RoleDataModel>>();

                if (! await roleManager.RoleExistsAsync("Manager")) 
                {
                    await roleManager.CreateAsync(new RoleDataModel()
                    {
                        Name ="Manager"
                    });
                }

            }
        }
    }
}
