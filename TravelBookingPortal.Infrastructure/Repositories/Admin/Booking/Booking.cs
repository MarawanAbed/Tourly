

using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Repositories.Admin.Booking;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Repositories.Admin.Booking
{
    public class Booking(TravelBookingPortalDbContext _context) : IBooking
    {
        public async Task AddBooking(Domain.Enitites.BookingEntities.Booking booking)
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

        public async Task<IEnumerable<Domain.Enitites.BookingEntities.Booking>> GetAllBookings()
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                .ThenInclude(r => r.Hotel)
                .ToListAsync();
        }

        public async Task UpdateBooking(Domain.Enitites.BookingEntities.Booking booking)
        {
            var existingBooking = await _context.Bookings.FindAsync(booking.BookingId);
            if (existingBooking != null)
            {
                existingBooking.CheckInDate = booking.CheckInDate;
                existingBooking.CheckOutDate = booking.CheckOutDate;
                existingBooking.TotalPrice = booking.TotalPrice;
                existingBooking.BookingStatus = booking.BookingStatus;
                existingBooking.CreatedAt = booking.CreatedAt;
                existingBooking.PaymentId = booking.PaymentId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
