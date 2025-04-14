using Microsoft.AspNetCore.SignalR;



namespace TravelBookingPortal.Infrastructure.Hubs
{
    public class BookingHub : Hub
    {
        public async Task ConfirmBooking(int bookingId)
        {
            await Clients.All.SendAsync("BookingConfirmed", bookingId);
        }

    }
}
