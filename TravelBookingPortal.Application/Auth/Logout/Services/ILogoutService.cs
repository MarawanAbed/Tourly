
namespace TravelBookingPortal.Application.Auth.Logout.Services
{
    public interface ILogoutService
    {
        Task Logout(string userId);
    }
}
