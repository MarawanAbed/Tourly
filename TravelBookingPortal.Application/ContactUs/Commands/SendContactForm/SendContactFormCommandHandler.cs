

using MediatR;
using TravelBookingPortal.Application.Services.ContactUs;

namespace TravelBookingPortal.Application.ContactUs.Commands.SendContactForm
{
    public class SendContactFormCommandHandler(IEmailService emailService) : IRequestHandler<SendContactFormCommand, bool>
    {
        public async Task<bool> Handle(SendContactFormCommand request, CancellationToken cancellationToken)
        {
            var subject = $"Contact Form Submission from {request.Name}";
            var body = $"Name: {request.Name}\nEmail: {request.Email}\nMessage: {request.Message}";

            return await emailService.SendEmailAsync("rehabmegahed2@gmail.com", subject, body, request.Email);
        }
    }
}
