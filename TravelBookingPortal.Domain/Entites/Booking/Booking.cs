using RoomEntities=TravelBookingPortal.Domain.Entites.Room.RoomEntities;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Domain.Entites.Booking
{
    public class BookingEntities
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public ApplicationUser? User { get; set; }
        public RoomEntities? Room { get; set; }
    }
}
