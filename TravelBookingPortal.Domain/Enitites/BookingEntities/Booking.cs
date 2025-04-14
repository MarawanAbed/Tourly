using TravelBookingPortal.Domain.Enitites.RoomEntities;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Domain.Enitites.BookingEntities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; } 
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? PaymentId { get; set; }

        public ApplicationUser? User { get; set; }
        public Room? Room { get; set; } 
    }
}
