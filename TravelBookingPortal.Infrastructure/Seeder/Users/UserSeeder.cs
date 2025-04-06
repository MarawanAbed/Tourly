

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Infrastructure.Seeder.Users
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
                new { Email = "admin@example.com", FirstName = "Admin", LastName = "User", Password = "Admin@123", Role = "Admin" },
                new { Email = "john.doe@example.com", FirstName = "John", LastName = "Doe", Password = "Password123@", Role = "User" },
                new { Email = "jane.smith@example.com", FirstName = "Jane", LastName = "Smith", Password = "Password123@", Role = "User" }
            };

            foreach (var userData in users)
            {
                if (await userManager.FindByEmailAsync(userData.Email) == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = userData.Email,
                        Email = userData.Email,
                        FirstName = userData.FirstName,
                        PhoneNumber = "1234567890",
                        State = "State",
                        City = "City",
                        Street="street",
                        LastName = userData.LastName,
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/User_icon_2.svg/1200px-User_icon_2.svg.png",
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
