using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using TravelBookingPortal.Application.Interfaces.Hubs;

namespace TravelBookingPortal.Infrastructure.Hubs
{
    public class BookingStatusNotifier : IBookingStatusNotifier
    {
        private readonly IHubContext<BookingStatusHub> _hubContext;

        public BookingStatusNotifier(IHubContext<BookingStatusHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyBookingStatusAsync(int roomId, string status)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveBookingStatus", roomId, status);
        }

    }
}
