

using AutoMapper;
using MediatR;
using TravelBookingPortal.Domain.Enitites.RoomEntities;
using TravelBookingPortal.Domain.Repositories.Admin.Rooms;

namespace TravelBookingPortal.Application.Admin.Rooms.Commands
{
    public class CreateRoomCommandHandler(IRooms rooms,IMapper mapper) : IRequestHandler<CreateRoomCommand>
    {
        public async Task Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {

            var room = mapper.Map<Room>(request);
            await rooms.AddRoom(room);
        }
    }
}
