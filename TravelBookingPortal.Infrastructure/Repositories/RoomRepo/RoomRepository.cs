using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Enitites.HotelEntities;
using TravelBookingPortal.Domain.Enitites.RoomEntities;
using TravelBookingPortal.Domain.Repositories.RoomRepo;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Repositories.RoomRepo
{
    public class RoomRepository : IRoomRepository
    {
        private readonly TravelBookingPortalDbContext _context;

        public RoomRepository(TravelBookingPortalDbContext _context)
        {
            this._context = _context;
        }

        public async Task AddBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomByCityAndAvailabilityAsync(string city, DateTime checkIn, DateTime checkOut, string roomType)
        {
            return await _context.Rooms
                .Include(r => r.Hotel)
                    .ThenInclude(h => h.City)
                .Where(r =>
                    r.IsAvailable &&
                    r.RoomType.ToLower() == roomType.ToLower() && 
                    r.Hotel.City.Name.ToLower() == city.ToLower() &&
                    !r.Bookings.Any(b =>
                        (checkIn < b.CheckOutDate) && (checkOut > b.CheckInDate)
                    )
                )
                .ToListAsync();
        }

    }
}
