using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Application.Services.Register
{
    public interface IRegisterService
    {
        Task<string> Register(ApplicationUser user, string password);

    }
}
