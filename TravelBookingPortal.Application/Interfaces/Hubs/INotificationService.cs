
namespace TravelBookingPortal.Application.Interfaces.Hubs
{
    public interface INotificationService
    {
        Task SendBookingConfirmedAsync(int bookingId);
    }
}
