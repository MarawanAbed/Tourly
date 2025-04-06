using TravelBookingPortal.Domain.Enitites.PreferenceEnitites;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Domain.Repositories.UserProfile
{
    public interface IProfileRepo
    {
        public Task<ApplicationUser> GetUserProfileAsync(string userId);
        public Task UpdateUserProfileAsync(string UserId, string FirstName,
         string LastName,
         string ImageUrl,
         string PhoneNumber,
         string? State,
         string? City,
         string? Street, List<Preference> prefrences);
    }
}
