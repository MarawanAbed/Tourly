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
       public Task<Booking> GetBookingByIdAsync(int bookingId);
       public Task UpdateAsync(Booking booking);

        public Task<Booking> GetLastBookingPendingForUserAsync(string userId);
        public Task<IEnumerable<Booking>> GetBookingByUserIdAsync(string userId);
    }
}
