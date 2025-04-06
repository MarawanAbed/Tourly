using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TravelBookingPortal.Application.Payment.Command.Model
{
    public class ConfirmBookingCommand : IRequest
    {
        public int BookingId { get; set; }
    }
}
