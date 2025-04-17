

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
        public async Task<string> Register(ApplicationUser applicationUser,string password)
        {

            var user =new ApplicationUser
            {
                UserName = applicationUser.UserName,
                Email = applicationUser.Email,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                ImageUrl = applicationUser.ImageUrl,
                PhoneNumber = applicationUser.PhoneNumber,
                State = applicationUser.State,
                City = applicationUser.City,
                DateOfBirth = applicationUser.DateOfBirth,
                Street = applicationUser.Street,
                CreatedAt = DateTime.UtcNow,
            };
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
                logger.LogInformation("User {Email} registered successfully.", applicationUser.Email);
                return _generateToken.GenerateJwtToken(user);
            }
            else
            {
                logger.LogWarning("User {Email} registration failed. Errors: {Errors}", applicationUser.Email, string.Join(", ", result.Errors.Select(e => e.Description)));
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
