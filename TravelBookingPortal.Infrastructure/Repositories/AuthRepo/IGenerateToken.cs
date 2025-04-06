using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Infrastructure.Repositories.AuthRepo
{
    public interface IGenerateToken
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}