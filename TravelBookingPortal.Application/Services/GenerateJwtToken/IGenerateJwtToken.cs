using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Application.Services.GenerateJwtToken
{
    public interface IGenerateJwtToken
    {
        string GenerateJwtToken(ApplicationUser user);

    }
}
