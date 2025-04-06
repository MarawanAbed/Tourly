using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TravelBookingPortal.Domain.IHubs;

namespace TravelBookingPortal.Infrastructure.Hubs
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<BookingHub> _hubContext;

        public NotificationService(IHubContext<BookingHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendBookingConfirmedAsync(int bookingId)
        {
            await _hubContext.Clients.All.SendAsync("BookingConfirmed", bookingId);
        }
    }
}
