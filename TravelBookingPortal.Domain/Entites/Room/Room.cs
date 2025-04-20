using BookingEntities=TravelBookingPortal.Domain.Entites.Booking.BookingEntities;
using HotelEntities= TravelBookingPortal.Domain.Entites.Hotel.HotelEntities;

namespace TravelBookingPortal.Domain.Entites.Room
{
    public class RoomEntities
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public string? ImageUrl { get; set; }

        public HotelEntities? Hotel { get; set; }
        public List<BookingEntities>? Bookings { get; set; }
    }
}
