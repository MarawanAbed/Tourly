
using MediatR;

namespace TravelBookingPortal.Application.Admin.Users.Commnads.ChangeRole
{
    public class ChangeUsersRoleCommnad : IRequest
    {
        public string UserId { get; set; }
    }
}
