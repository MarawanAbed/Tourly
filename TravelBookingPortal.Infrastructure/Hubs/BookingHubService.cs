using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TravelBookingPortal.Domain.IHubs;

namespace TravelBookingPortal.Infrastructure.Hubs
{
    class BookingHubService : IBookingHub
    {
        private readonly IHubContext<BookingHub> _hubContext;

        public BookingHubService(IHubContext<BookingHub> hubContext)
        {
            _hubContext = hubContext;

        }
        public async  Task SendBookingUpdate(string status)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveBookingUpdate", status);
        }
    }
}
