using Microsoft.AspNetCore.Identity;
using ParaglidingServices.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Helpers
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            if (await roleManager.FindByNameAsync(AuthorizeRole.Administrator) == null)
            {
                await roleManager.CreateAsync(new Role(AuthorizeRole.Administrator));
            }
            if (await roleManager.FindByNameAsync(AuthorizeRole.Pilot) == null)
            {
                await roleManager.CreateAsync(new Role(AuthorizeRole.Pilot));
            }
            if (await roleManager.FindByNameAsync(AuthorizeRole.PilotInstructor) == null)
            {
                await roleManager.CreateAsync(new Role(AuthorizeRole.PilotInstructor));
            }
            if (await roleManager.FindByNameAsync(AuthorizeRole.Organizer) == null)
            {
                await roleManager.CreateAsync(new Role(AuthorizeRole.Organizer));
            }

            var user = await userManager.FindByNameAsync("administrator");
            if (user == null)
            {
                var adminUser = new User
                {

                };
                var result = await userManager.CreateAsync(adminUser, "Admin12345!");
                if (result.Succeeded)
                {
                    await userManager.AddToRolesAsync(adminUser,
                        new List<string> { AuthorizeRole.Administrator, AuthorizeRole.Pilot, AuthorizeRole.PilotInstructor, AuthorizeRole.Organizer });
                }
            }
        }
    }
}
