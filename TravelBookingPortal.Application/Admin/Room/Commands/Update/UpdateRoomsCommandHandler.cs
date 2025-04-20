

using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Room;
using TravelBookingPortal.Domain.Entites.Room;


namespace TravelBookingPortal.Application.Admin.Room.Commands.Update
{
    public class UpdateRoomsCommandHandler(IRoomRepository rooms,IMapper mapper) : IRequestHandler<UpdateRoomsCommand>
    {
        public async Task Handle(UpdateRoomsCommand request, CancellationToken cancellationToken)
        {
            
            var room=mapper.Map<RoomEntities>(request);

            await rooms.UpdateRoom(room);

        }
    }
    
}
