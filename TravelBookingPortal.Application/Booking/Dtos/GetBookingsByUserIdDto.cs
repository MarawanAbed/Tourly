

namespace TravelBookingPortal.Application.Booking.Dtos
{
    class GetBookingsByUserIdDto
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public decimal PricePerNight { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BookingStatus { get; set; }
        public string HotelName { get; set; }
        public string CityName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
