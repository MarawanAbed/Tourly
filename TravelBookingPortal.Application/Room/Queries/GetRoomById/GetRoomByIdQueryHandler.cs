using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Room;
using TravelBookingPortal.Application.Room.Dtos;
using TravelBookingPortal.Application.Room.Queries.GetAvailableRooms;

namespace TravelBookingPortal.Application.Room.Queries.GetRoomById
{
    class GetRoomByIdQueryHandler(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<GetRoomByIdQuery, GetOneRoomDTO>
    {
        public async Task<GetOneRoomDTO> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await roomRepository.GetRoomByIdAsync(request.Id);
            var roomMapper = mapper.Map<GetOneRoomDTO>(room);
            return roomMapper;
        }
    }
}
