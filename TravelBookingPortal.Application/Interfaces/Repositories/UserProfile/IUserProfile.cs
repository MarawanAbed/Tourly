using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Application.Interfaces.Repositories.UserProfile
{
    public interface IUserProfileRepository
    {
        public Task<ApplicationUser> GetUserProfileAsync(string userId);
        public Task<bool> UpdateUserProfileAsync(string UserId, string FirstName,
         string LastName,
         string? ImageUrl,
         string PhoneNumber,
         string? State,
         string? City,
         string? Street, string Email, string UserName);
    }
}
