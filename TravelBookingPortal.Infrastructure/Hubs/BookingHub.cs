using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
