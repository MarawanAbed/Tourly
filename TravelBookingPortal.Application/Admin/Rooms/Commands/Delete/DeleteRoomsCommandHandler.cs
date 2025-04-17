

using MediatR;
using TravelBookingPortal.Domain.Repositories.Admin.Rooms;

namespace TravelBookingPortal.Application.Admin.Rooms.Commands.Delete
{
    public class DeleteRoomsCommandHandler(IRooms rooms): IRequestHandler<DeleteRoomsCommand>
    {
        public async Task Handle(DeleteRoomsCommand request, CancellationToken cancellationToken)
        {
            var roomId = request.RoomId;
            if (roomId == 0)
            {
                throw new ArgumentException("Room ID cannot be zero.");
            }
            await rooms.DeleteRoom(request.RoomId);
        }
    }
}
