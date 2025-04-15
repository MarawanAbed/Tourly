

using MediatR;

namespace TravelBookingPortal.Application.Admin.Users.Commnads.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
