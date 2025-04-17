

using AutoMapper;
using MediatR;
using TravelBookingPortal.Domain.Repositories.Admin.Rooms;

namespace TravelBookingPortal.Application.Admin.Rooms.Commands.Update
{
    public class UpdateRoomsCommandHandler(IRooms rooms,IMapper mapper) : IRequestHandler<UpdateRoomsCommand>
    {
        public async Task Handle(UpdateRoomsCommand request, CancellationToken cancellationToken)
        {
            
            var room=mapper.Map<Domain.Enitites.RoomEntities.Room>(request);

            await rooms.UpdateRoom(room);

        }
    }
    
}
