using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Domain.Repositories.RoomRepo
{
    public interface IRoomRepository
    {
        public Task<IEnumerable<Room>> GetRoomByCityAndAvailabilityAsync(string city, DateTime checkIn, DateTime checkOut, string roomType);
        public Task AddBookingAsync(Booking booking);
    }
}
