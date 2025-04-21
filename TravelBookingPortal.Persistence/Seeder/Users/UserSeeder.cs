

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TravelBookingPortal.Application.Interfaces.Seeder.Users;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Persistence.Seeder.Users
{
    public class UserSeeder(
        UserManager<ApplicationUser> userManager,
        ILogger<UserSeeder> logger
        ) : IUserSeeder
    {

        public async Task SeedUsers()
        {
            var users = new[]
    {
                new { Email = "admin@tourly.com",UserName="AhmedAli", FirstName = "Ahmed", LastName = "Ali", Password = "Admin@123", Role = "Admin" },
            };

            foreach (var userData in users)
            {
                if (await userManager.FindByEmailAsync(userData.Email) == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = userData.UserName,
                        Email = userData.Email,
                        FirstName = userData.FirstName,
                        PhoneNumber = "1234567890",
                        ImageUrl= "https://images.unsplash.com/photo-1633332755192-727a05c4013d?q=80&w=2080&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        State = "State",
                        City = "City",
                        Street = "street",
                        LastName = userData.LastName,
                        CreatedAt = DateTime.UtcNow
                    };

                    var result = await userManager.CreateAsync(user, userData.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, userData.Role);
                        logger.LogInformation($"User {userData.Email} created.");
                    }
                    else
                    {
                        logger.LogError($"Failed to create user {userData.Email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                        throw new Exception($"User creation failed for {userData.Email}");
                    }
                }
                else
                {
                    logger.LogInformation($"User {userData.Email} already exists.");
                }
            }

        }

    }
}
