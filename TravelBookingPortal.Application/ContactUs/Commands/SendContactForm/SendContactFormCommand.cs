
using MediatR;

namespace TravelBookingPortal.Application.ContactUs.Commands.SendContactForm
{
    public class SendContactFormCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
