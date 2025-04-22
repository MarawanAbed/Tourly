using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Application.Services.Register
{
    public interface IRegisterService
    {
        Task<(bool Success, string Token, string Message)> Register(ApplicationUser user, string password);

    }
}
