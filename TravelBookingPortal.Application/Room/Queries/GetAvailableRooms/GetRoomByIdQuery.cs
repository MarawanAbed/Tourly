
using MediatR;
using TravelBookingPortal.Application.Room.Dtos;

namespace TravelBookingPortal.Application.Room.Queries.GetAvailableRooms
{
    public class GetRoomByIdQuery : IRequest<GetOneRoomDTO>
    {
        public int Id { get; set; }
    }

}
