
using MediatR;

namespace TravelBookingPortal.Application.Room.Commands
{
    public class BookRoomCommand : IRequest
    {
        public string UserId { get; set; }

        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
