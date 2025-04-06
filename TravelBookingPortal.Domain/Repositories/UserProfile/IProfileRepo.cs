using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Enitites.PreferenceEnitites;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Domain.Repositories.Profile
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
