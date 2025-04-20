

using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Room;


namespace TravelBookingPortal.Application.Admin.Room.Commands.Delete
{
    public class DeleteRoomsCommandHandler(IRoomRepository rooms): IRequestHandler<DeleteRoomsCommand>
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
