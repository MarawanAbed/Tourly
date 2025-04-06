using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.RoomLogic.Dtos;
using TravelBookingPortal.Application.RoomLogic.Queries.Models;
using TravelBookingPortal.Domain.Repositories.RoomRepo;

namespace TravelBookingPortal.Application.RoomLogic.Queries.Handlers
{
    class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, GetOneRoomDTO>
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;

        public GetRoomByIdQueryHandler(IRoomRepository roomRepository, IMapper mapper)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }
        public async Task<GetOneRoomDTO> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await roomRepository.GetRoomByIdAsync(request.Id);
            var roomMapper = mapper.Map<GetOneRoomDTO>(room);
            return roomMapper;
        }
    }
}
