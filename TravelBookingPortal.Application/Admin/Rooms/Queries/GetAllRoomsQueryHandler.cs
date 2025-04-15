

using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.Rooms.Dtos;
using TravelBookingPortal.Domain.Repositories.Admin.Rooms;

namespace TravelBookingPortal.Application.Admin.Rooms.Queries
{
    public class GetAllRoomsQueryHandler(IMapper mapper,IRooms rooms) : IRequestHandler<GetAllRoomsQuery, List<GetAllRoomsDto>>
    {
        public async Task<List<GetAllRoomsDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var roomsList = await rooms.GetAllRooms();
            return mapper.Map<List<GetAllRoomsDto>>(roomsList);
        }
    }

}
