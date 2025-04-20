

using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Application.Services.Logout;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Infrastructure.Services.Logout
{
    public class LogoutService(SignInManager<ApplicationUser> _signInManager) : ILogoutService
    {
        public async Task Logout(string userId)
        {
            var user = await _signInManager.UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            await _signInManager.SignOutAsync();
            //logger.LogInformation("User {Email} logged out successfully.", user.Email);
        }
    }
}
