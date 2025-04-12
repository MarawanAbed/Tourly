

using MediatR;

namespace TravelBookingPortal.Application.Auth.logout.Commands
{
    public class LogoutCommand : IRequest
    {
        public string UserId { get; set; }

    }
}
