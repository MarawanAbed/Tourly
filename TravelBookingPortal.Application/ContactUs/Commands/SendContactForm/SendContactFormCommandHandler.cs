using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Domain.Repositories.ContuctUs;

namespace TravelBookingPortal.Application.ContactUs.Commands.SendContactForm
{
    public class SendContactFormCommandHandler : IRequestHandler<SendContactFormCommand, bool>
    {
        private readonly IEmailService _emailService;

        public SendContactFormCommandHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<bool> Handle(SendContactFormCommand request, CancellationToken cancellationToken)
        {
            var subject = $"Contact Form Submission from {request.Name}";
            var body = $"Name: {request.Name}\nEmail: {request.Email}\nMessage: {request.Message}";

            return await _emailService.SendEmailAsync("rehabmegahed2@gmail.com", subject, body, request.Email);
        }
    }
}
