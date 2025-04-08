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

        public string PhoneNumber { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Street { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
