

using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Application.Auth.Services
{
    public interface IGenerateJwtToken
    {
        string GenerateJwtToken(ApplicationUser user);

    }
}
