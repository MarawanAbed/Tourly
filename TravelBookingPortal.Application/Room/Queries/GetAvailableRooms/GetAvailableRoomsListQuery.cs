
using MediatR;
using TravelBookingPortal.Application.Room.Dtos;

namespace TravelBookingPortal.Application.Room.Queries.GetAvailableRooms
{
    public class GetAvailableRoomsListQuery : IRequest<IEnumerable<GetRoomsDTO>>
    {

        public string City { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string RoomType { get; set; }

    }
}
