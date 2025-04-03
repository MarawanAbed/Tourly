using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Enitites.ReviewEntities;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Domain.Enitites.HotelEntities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public List<Room> Rooms { get; set; } // New relationship
        public List<Booking> Bookings { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
