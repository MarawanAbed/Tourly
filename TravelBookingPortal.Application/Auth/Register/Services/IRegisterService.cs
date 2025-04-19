

using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Application.Auth.Register.Services
{
    public interface IRegisterService
    {
        Task<string> Register(ApplicationUser user, string password);

    }
}
