using Microsoft.AspNetCore.SignalR;
using TravelBookingPortal.Domain.IHubs;



namespace TravelBookingPortal.Infrastructure.Hubs
{
    public class BookingHub : Hub,IBookingHub
    {
        public async Task SendBookingUpdate( string status)
        {
            await Clients.All.SendAsync("ReceiveBookingUpdate",  status);
        }
    }
}
