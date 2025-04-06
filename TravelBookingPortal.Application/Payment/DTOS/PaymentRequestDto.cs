using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingPortal.Application.Payment.DTOS
{
    public class PaymentRequestDto
    {
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
    }
}
