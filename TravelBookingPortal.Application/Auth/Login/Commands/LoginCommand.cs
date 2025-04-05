

using MediatR;
using TravelBookingPortal.Application.Auth.Login.Response;

namespace TravelBookingPortal.Application.Auth.Login.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
