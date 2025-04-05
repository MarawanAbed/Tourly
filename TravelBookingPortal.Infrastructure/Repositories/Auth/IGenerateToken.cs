using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Infrastructure.Repositories.Auth
{
    public interface IGenerateToken
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}