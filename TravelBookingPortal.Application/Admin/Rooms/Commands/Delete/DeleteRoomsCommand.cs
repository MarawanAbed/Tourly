

using MediatR;

namespace TravelBookingPortal.Application.Admin.Rooms.Commands.Delete
{
    public class DeleteRoomsCommand : IRequest
    {
        public int RoomId { get; set; }
    }
}
