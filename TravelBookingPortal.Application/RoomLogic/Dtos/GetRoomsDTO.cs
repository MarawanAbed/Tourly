
namespace TravelBookingPortal.Application.RoomLogic.Dtos
{
    public class GetRoomsDTO
    {
        public int RoomId { get; set; }
        public string HotelName { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; } 
        public decimal PricePerNight { get; set; }
        public string ImageUrl { get; set; }
        public string BookingStatus { get; set; }
        public bool IsBookable { get; set; }
    }
}
