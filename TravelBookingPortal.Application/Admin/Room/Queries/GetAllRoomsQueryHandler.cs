

using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.Room.Dtos;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Room;


namespace TravelBookingPortal.Application.Admin.Room.Queries
{
    public class GetAllRoomsQueryHandler(IMapper mapper,IRoomRepository rooms) : IRequestHandler<GetAllRoomsQuery, List<GetAllRoomsDto>>
    {
        public async Task<List<GetAllRoomsDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var roomsList = await rooms.GetAllRooms();
            return mapper.Map<List<GetAllRoomsDto>>(roomsList);
        }
    }

}
