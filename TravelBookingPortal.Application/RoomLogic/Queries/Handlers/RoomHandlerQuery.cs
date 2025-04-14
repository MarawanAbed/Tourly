using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.RoomLogic.Dtos;
using TravelBookingPortal.Application.RoomLogic.Queries.Models;
using TravelBookingPortal.Application.RoomLogic.Queries.RoomService.Abstraction;

namespace TravelBookingPortal.Application.RoomLogic.Queries.Handlers
{
    class RoomHandlerQuery : IRequestHandler<GetAvailableRoomsListQuery, IEnumerable<GetRoomsDTO>>
    {
        private readonly IRoomService roomService;
        private readonly IMapper mapper;

        public RoomHandlerQuery(IRoomService roomService,IMapper mapper)
        {
            this.roomService = roomService;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<GetRoomsDTO>> Handle(GetAvailableRoomsListQuery request, CancellationToken cancellationToken)
        {
            var roomList =await roomService.GetAvailableRoomsAsync(request.City, request.CheckIn, request.CheckOut, request.RoomType);
            var roomListMapper = mapper.Map<IEnumerable<GetRoomsDTO>>(roomList);
            return roomListMapper;
        }
    }
}
