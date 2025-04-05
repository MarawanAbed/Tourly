using MediatR;
using TravelBookingPortal.Application.Auth.Register.Response;

namespace TravelBookingPortal.Application.Auth.Register.Commands
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; } 
    }
}
