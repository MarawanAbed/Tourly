using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TravelBookingPortal.Application.Payment.Command.Model
{
    public class ConfirmBookingAfterPaymentCommand : IRequest<Unit>
    {
       
        
        public int BookingId { get; }
        public ConfirmBookingAfterPaymentCommand(int bookingId)
        {
            BookingId = bookingId;
        }

        
    }
}
