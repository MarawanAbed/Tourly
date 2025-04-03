
using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Enitites.ItineraryEntities;
using TravelBookingPortal.Domain.Enitites.PreferenceEnitites;
using TravelBookingPortal.Domain.Enitites.ReviewEntities;

namespace TravelBookingPortal.Domain.Enitites.User
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Preference> Preferences { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Itinerary> Itineraries { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
