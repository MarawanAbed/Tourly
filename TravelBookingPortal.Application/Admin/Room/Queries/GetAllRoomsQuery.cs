

using MediatR;
using TravelBookingPortal.Application.Admin.Room.Dtos;

namespace TravelBookingPortal.Application.Admin.Room.Queries
{
    public class GetAllRoomsQuery : IRequest<List<GetAllRoomsDto>>
    {
    }

}
