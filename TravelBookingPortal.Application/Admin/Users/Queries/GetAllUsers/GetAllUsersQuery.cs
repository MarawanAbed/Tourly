
using MediatR;
using TravelBookingPortal.Application.Admin.Users.Dtos;

namespace TravelBookingPortal.Application.Admin.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UsersDto>>
    {
    }

}
