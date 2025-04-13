

using MediatR;
using TravelBookingPortal.Application.Admin.Rooms.Dtos;

namespace TravelBookingPortal.Application.Admin.Rooms.Queries
{
    public class GetAllRoomsQuery : IRequest<List<GetAllRoomsDto>>
    {
        public int HotelId { get; set; }
    }

}
