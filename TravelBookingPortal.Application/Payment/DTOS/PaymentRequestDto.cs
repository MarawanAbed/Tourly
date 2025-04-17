

namespace TravelBookingPortal.Application.Payment.DTOS
{
    public class PaymentRequestDto
    {
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
    }
}
