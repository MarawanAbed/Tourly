
using Microsoft.EntityFrameworkCore;
using BookingEntities = TravelBookingPortal.Domain.Entites.Booking.BookingEntities;
using RoomEntities = TravelBookingPortal.Domain.Entites.Room.RoomEntities;
using TravelBookingPortal.Application.Interfaces.Repositories.Room;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Repositories.Room
{
    public class RoomRepository(TravelBookingPortalDbContext _context) : IRoomRepository
    {
        public async Task AddBookingAsync(string UserId, int RoomId, DateTime CheckIn, DateTime CheckOut, decimal TotalPrice)
        {
            BookingEntities booking = new BookingEntities
            {
                UserId = UserId,
                RoomId = RoomId,
                CheckInDate = CheckIn,
                CheckOutDate = CheckOut,
                TotalPrice = TotalPrice,
                BookingStatus = "Pending",
                CreatedAt = DateTime.UtcNow
            };
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<RoomEntities>> GetRoomByCityAndAvailabilityAsync(string city, DateTime checkIn, DateTime checkOut, string roomType)
        {
            return await _context.Rooms
            .Include(r => r.Bookings)
            .Include(r => r.Hotel)
            .ThenInclude(h => h.City)


            .Where(r =>

                    r.RoomType.ToLower() == roomType.ToLower() &&
                    r.Hotel.City.Name.ToLower() == city.ToLower() &&
                    !r.Bookings.Any(b =>
                        checkIn < b.CheckOutDate && checkOut > b.CheckInDate &&
                     b.BookingStatus != "Pending"
                    )
                )
                .ToListAsync();


        }

        public async Task<RoomEntities> GetRoomByIdAsync(int roomId)
        {
            return await _context.Rooms
                 .Include(r => r.Hotel)
                 .ThenInclude(h => h.City)
                 .FirstOrDefaultAsync(r => r.RoomId == roomId);
        }
    }
}
