using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Enitites.BookingEntities;

namespace TravelBookingPortal.Domain.Repositories.BookingRepo
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task UpdateAsync(Booking booking);

        public Task<Booking> GetLastBookingPendingForUserAsync(string userId);
    }
}
