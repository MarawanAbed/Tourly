
using Microsoft.AspNetCore.Identity;
using BookingEntities=TravelBookingPortal.Domain.Entites.Booking.BookingEntities;
using ReviewEntities= TravelBookingPortal.Domain.Entites.Review.ReviewEntities;
using ItineraryEntities = TravelBookingPortal.Domain.Entites.Itinerary.ItineraryEntities;

namespace TravelBookingPortal.Domain.Entites.User
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Street { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<BookingEntities>? Bookings { get; set; }
        public List<ItineraryEntities>? Itineraries { get; set; }
        public List<ReviewEntities>? Reviews { get; set; }
    }
}
