using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingPortal.Application.Payment.PaymentService
{
   public interface IPaymentService
    {
        Task<string> GeneratePaymentUrl(decimal amount, int bookingId);
    }
}
