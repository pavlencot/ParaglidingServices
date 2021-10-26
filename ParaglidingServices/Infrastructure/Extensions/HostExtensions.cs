using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParaglidingServices.Api.Helpers;
using ParaglidingServices.Domain.Entities.Auth;
using ParaglidingServices.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Infrastructure.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    var ctx = service.GetRequiredService<AppDbContext>();
                    
                    var roleManager = service.GetRequiredService<RoleManager<Role>>();
                    var userManager = service.GetRequiredService<UserManager<User>>();
                    ctx.Database.Migrate();

                    await RoleInitializer.InitializeAsync(roleManager, userManager);
                }
                catch (Exception ex)
                {
                    var logger = service.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
        }
    }
}
