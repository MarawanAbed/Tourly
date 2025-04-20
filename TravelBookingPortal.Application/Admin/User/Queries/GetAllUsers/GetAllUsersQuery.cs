
using MediatR;
using TravelBookingPortal.Application.Admin.User.Dtos;

namespace TravelBookingPortal.Application.Admin.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UsersDto>>
    {
    }

}
