
using MediatR;

namespace TravelBookingPortal.Application.Admin.User.Commnads.ChangeRole
{
    public class ChangeUsersRoleCommnad : IRequest
    {
        public string UserId { get; set; }
    }
}
