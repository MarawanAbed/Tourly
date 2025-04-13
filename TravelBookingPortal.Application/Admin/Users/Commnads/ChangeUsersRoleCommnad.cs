
using MediatR;

namespace TravelBookingPortal.Application.Admin.Users.Commnads
{
    public class ChangeUsersRoleCommnad : IRequest
    {
        public string UserId { get; set; }
    }
}
