
namespace TravelBookingPortal.Domain.Repositories.AuthRepo
{
    public interface ILogoutRepository
    {
        Task Logout(string userId);

    }
}
