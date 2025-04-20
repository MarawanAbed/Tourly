

namespace TravelBookingPortal.Application.Payment.Dtos
{
    public class PaymentRequestDto
    {
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
    }
}
