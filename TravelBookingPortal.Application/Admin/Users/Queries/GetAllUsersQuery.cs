
using MediatR;
using TravelBookingPortal.Application.Admin.Users.Dtos;

namespace TravelBookingPortal.Application.Admin.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UsersDto>>
    {
    }

}
