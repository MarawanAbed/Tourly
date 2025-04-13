using MediatR;

namespace TravelBookingPortal.Application.Admin.Rooms.Commands
{
    public class CreateRoomCommand :IRequest 
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; }
    }
}
