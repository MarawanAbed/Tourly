

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.AuthRepo;

namespace TravelBookingPortal.Infrastructure.Repositories.AuthRepo
{
    public class LoginRepositoryImplementation(
        UserManager<ApplicationUser> _userManager,
        IConfiguration _configuration,ILogger<LoginRepositoryImplementation>logger,
        IGenerateToken _generateToken
        ) : ILoginRepository
    {
        public async Task<string?> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                logger.LogInformation("User {Email} logged in successfully.", email);
                return _generateToken.GenerateJwtToken(user);
            }
            logger.LogWarning("Invalid login attempt for user {Email}.", email);
            throw new Exception("Invalid login attempt.");
        }

    }

}
    