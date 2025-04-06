

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.AuthRepo;

namespace TravelBookingPortal.Infrastructure.Repositories.AuthRepo
{
    public class RegisterRepositoryImplementation(
        UserManager<ApplicationUser> userManager, ILogger<RegisterRepositoryImplementation> logger,
        IGenerateToken _generateToken) : IRegisterRepoistory
    {
        public async Task<string> Register(string email, string password, string firstName, string lastName, string imageUrl)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                ImageUrl = imageUrl,
            };
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
                logger.LogInformation("User {Email} registered successfully.", email);
                return _generateToken.GenerateJwtToken(user);
            }
            else
            {
                logger.LogWarning("User {Email} registration failed. Errors: {Errors}", email, string.Join(", ", result.Errors.Select(e => e.Description)));
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
