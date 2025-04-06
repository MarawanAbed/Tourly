
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.RoomLogic.Dtos;
using TravelBookingPortal.Application.RoomLogic.Queries.Models;

using TravelBookingPortal.Domain.Repositories.RoomRepo;

namespace TravelBookingPortal.Application.RoomLogic.Queries.Handlers
{
    class RoomHandlerQuery : IRequestHandler<GetAvailableRoomsListQuery, IEnumerable<GetRoomsDTO>>
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;

        public RoomHandlerQuery(IRoomRepository roomRepository,IMapper mapper)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<GetRoomsDTO>> Handle(GetAvailableRoomsListQuery request, CancellationToken cancellationToken)
        {
            var roomList =await roomRepository.GetRoomByCityAndAvailabilityAsync(request.City, request.CheckIn, request.CheckOut, request.RoomType);
            var roomListMapper = mapper.Map<IEnumerable<GetRoomsDTO>>(roomList);
            return roomListMapper;
        }
    }
}
