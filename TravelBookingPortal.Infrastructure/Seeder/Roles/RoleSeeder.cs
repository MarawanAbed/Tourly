

using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Infrastructure.Seeder.Roles
{
    public class RoleSeeder(
        RoleManager<IdentityRole> roleManager) : IRoleSeeder
    {
        public async Task SeedRoles()
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
