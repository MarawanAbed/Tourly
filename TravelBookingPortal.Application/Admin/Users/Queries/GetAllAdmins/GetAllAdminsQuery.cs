
using MediatR;
using TravelBookingPortal.Application.Admin.Users.Dtos;

namespace TravelBookingPortal.Application.Admin.Users.Queries.GetAllAdmins
{
    public class GetAllAdminsQuery : IRequest<IEnumerable<UsersDto>>
    {
    }
}
