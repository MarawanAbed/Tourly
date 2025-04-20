
namespace TravelBookingPortal.Application.Admin.Room.Dtos
{
    public class GetAllRoomsDto
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; }

        public string HotelName { get; set; }
    }
}
