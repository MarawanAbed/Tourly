using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingPortal.Domain.IHubs
{
    public interface INotificationService
    {
        Task SendBookingConfirmedAsync(int bookingId);
    }
}
