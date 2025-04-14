
namespace TravelBookingPortal.Application.RoomLogic.Dtos
{
    public class GetRoomsDTO
    {
        public string HotelName { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; } 
        public decimal PricePerNight { get; set; }
    }
}
