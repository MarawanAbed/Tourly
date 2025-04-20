using BookingEntities = TravelBookingPortal.Domain.Entites.Booking.BookingEntities;
using CityEntities=TravelBookingPortal.Domain.Entites.City.CityEntities;
using RoomEntities = TravelBookingPortal.Domain.Entites.Room.RoomEntities;
using ReviewEntities = TravelBookingPortal.Domain.Entites.Review.ReviewEntities;

namespace TravelBookingPortal.Domain.Entites.Hotel
{
    public class HotelEntities
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }

        public List<RoomEntities>? Rooms { get; set; }
        public List<BookingEntities>? Bookings { get; set; }
        public List<ReviewEntities>? Reviews { get; set; }


        public CityEntities? City { get; set; }

        public int CityId { get; set; }
    }
}
