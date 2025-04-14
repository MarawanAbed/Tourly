

namespace TravelBookingPortal.Application.RoomLogic.Dtos
{
    class BookingRoomDTO
    {
        public string UserId { get; set; }
        public int RoomId { get; set; } // Changed from HotelId
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
