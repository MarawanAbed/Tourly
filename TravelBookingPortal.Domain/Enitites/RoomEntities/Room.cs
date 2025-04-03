using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Enitites.HotelEntities;

namespace TravelBookingPortal.Domain.Enitites.RoomEntities
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; } // e.g., "Single", "Double"
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        public Hotel Hotel { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
