

using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.Auth;

namespace TravelBookingPortal.Infrastructure.Repositories.Auth
{
    public class LogoutRepositoryImplementation(SignInManager<ApplicationUser> _signInManager) : ILogoutRepoistory
    {
        public async Task Logout()
        {
             await _signInManager.SignOutAsync();
        }
    }
}
