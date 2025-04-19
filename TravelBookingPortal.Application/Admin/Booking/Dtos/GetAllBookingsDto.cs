

namespace TravelBookingPortal.Application.Admin.Booking.Dtos
{
    public class GetAllBookingsDto
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingStatus { get; set; }
        public int BookingId { get; set; }

        public string HotelName { get; set; }

        public string UserName { get; set; }
    }
}
