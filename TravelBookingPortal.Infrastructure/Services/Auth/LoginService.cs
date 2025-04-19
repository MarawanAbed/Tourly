

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TravelBookingPortal.Application.Auth.Login.Services;
using TravelBookingPortal.Application.Auth.Services;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Infrastructure.Services.Auth
{
    public class LoginService(UserManager<ApplicationUser> _userManager, IGenerateJwtToken _generateToken,ILogger<LoginService> logger) : ILoginService
    {
        public async Task<string> GetUserId(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return user.Id;
        }

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
