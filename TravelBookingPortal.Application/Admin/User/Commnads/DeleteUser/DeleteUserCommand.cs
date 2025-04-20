

using MediatR;

namespace TravelBookingPortal.Application.Admin.User.Commnads.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
