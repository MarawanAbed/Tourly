
using MediatR;
using TravelBookingPortal.Application.Admin.User.Dtos;

namespace TravelBookingPortal.Application.Admin.User.Queries.GetAllAdmins
{
    public class GetAllAdminsQuery : IRequest<IEnumerable<UsersDto>>
    {
    }
}
