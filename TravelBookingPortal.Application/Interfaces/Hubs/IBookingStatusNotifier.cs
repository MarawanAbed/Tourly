

namespace TravelBookingPortal.Application.Interfaces.Hubs
{
    public interface IBookingStatusNotifier
    {
        Task NotifyBookingStatusAsync(int roomId, string status);
    }
}
