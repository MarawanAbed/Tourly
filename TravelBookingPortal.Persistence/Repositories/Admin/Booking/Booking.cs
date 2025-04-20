

using Microsoft.EntityFrameworkCore;
using BookingEntities = TravelBookingPortal.Domain.Entites.Booking.BookingEntities;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Booking;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Repositories.Admin.Booking
{
    public class BookingRepository(TravelBookingPortalDbContext _context) : IBookingRepository
    {
        public async Task AddBooking(BookingEntities booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookingEntities>> GetAllBookings()
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                .ThenInclude(r => r.Hotel)
                .ToListAsync();
        }

        public async Task UpdateBooking(BookingEntities booking)
        {
            var existingBooking = await _context.Bookings.FindAsync(booking.BookingId);
            if (existingBooking != null)
            {
                existingBooking.CheckInDate = booking.CheckInDate;
                existingBooking.CheckOutDate = booking.CheckOutDate;
                existingBooking.TotalPrice = booking.TotalPrice;
                existingBooking.BookingStatus = booking.BookingStatus;
                existingBooking.CreatedAt = booking.CreatedAt;
                await _context.SaveChangesAsync();
            }
        }
    }
}
