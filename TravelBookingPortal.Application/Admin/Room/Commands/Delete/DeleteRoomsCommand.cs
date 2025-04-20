

using MediatR;

namespace TravelBookingPortal.Application.Admin.Room.Commands.Delete
{
    public class DeleteRoomsCommand : IRequest
    {
        public int RoomId { get; set; }
    }
}
