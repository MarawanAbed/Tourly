

namespace TravelBookingPortal.Application.Payment.PaymentService
{
    public interface IPaymentService
    {
        Task<string> GeneratePaymentUrl(decimal amount, int bookingId);
    }
}
