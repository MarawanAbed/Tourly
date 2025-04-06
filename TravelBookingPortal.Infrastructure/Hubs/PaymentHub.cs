using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TravelBookingPortal.Infrastructure.Hubs
{
    public class PaymentHub : Hub
    {
        public async Task ConfirmBooking(int bookingId)
        {
            await Clients.All.SendAsync("BookingConfirmed", bookingId);
        }
    }
}
