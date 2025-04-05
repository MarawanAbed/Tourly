using Microsoft.AspNetCore.SignalR;


namespace TravelBookingPortal.Infrastructure.Hubs
{
    public class BookingHub : Hub
    {
        public async Task SendBookingUpdate(int bookingId, string status)
        {
            await Clients.All.SendAsync("ReceiveBookingUpdate", bookingId, status);
        }
    }
}
