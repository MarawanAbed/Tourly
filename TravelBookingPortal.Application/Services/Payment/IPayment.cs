namespace TravelBookingPortal.Application.Services.Payment
{
    public interface IPaymentService
    {
        Task<string> GeneratePaymentUrl(decimal amount, int bookingId);
    }
}
