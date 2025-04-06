

using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.AuthRepo;

namespace TravelBookingPortal.Infrastructure.Repositories.AuthRepo
{
    public class LogoutRepositoryImplementation(SignInManager<ApplicationUser> _signInManager) : ILogoutRepository
    {
        public async Task Logout()
        {
             await _signInManager.SignOutAsync();
        }
    }
}
