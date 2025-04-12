

using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.AuthRepo;

namespace TravelBookingPortal.Infrastructure.Repositories.AuthRepo
{
    public class LogoutRepositoryImplementation(SignInManager<ApplicationUser> _signInManager) : ILogoutRepository
    {
        public async Task Logout(string userId)
        {
            var user = await _signInManager.UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _signInManager.SignOutAsync();
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }
}
