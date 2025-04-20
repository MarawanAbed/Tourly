

using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Room;
using TravelBookingPortal.Domain.Entites.Room;


namespace TravelBookingPortal.Application.Admin.Room.Commands.Create
{
    public class CreateRoomCommandHandler(IRoomRepository rooms, IMapper mapper) : IRequestHandler<CreateRoomCommand>
    {
        public async Task Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {

            var room = mapper.Map<RoomEntities>(request);
            await rooms.AddRoom(room);
        }
    }
}
