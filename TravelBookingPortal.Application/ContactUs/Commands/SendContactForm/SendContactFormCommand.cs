using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
