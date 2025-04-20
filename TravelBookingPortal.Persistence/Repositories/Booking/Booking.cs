
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelBookingPortal.Application.Interfaces.Repositories.Booking;
using TravelBookingPortal.Persistence.Persistence;
using BookingEntities = TravelBookingPortal.Domain.Entites.Booking.BookingEntities;

namespace TravelBookingPortal.Persistence.Repositories.Booking
{
    public class BookingRepository(TravelBookingPortalDbContext context, ILogger<BookingRepository> logger) : IBookingRepository
    {


        public async Task DeleteBookingForUserAsync(int bookingId)
        {
            context.Bookings.Remove(new BookingEntities { BookingId = bookingId });
            await context.SaveChangesAsync();


        }

        public async Task<BookingEntities> GetBookingByIdAsync(int id)

        {
            return await context.Bookings
       .AsNoTracking()
       .FirstOrDefaultAsync(b => b.BookingId == id);


        }

        public async Task<IEnumerable<BookingEntities>> GetBookingByUserIdAsync(string userId)
        {
            return await context.Bookings
                .Include(b => b.Room).ThenInclude(c => c.Hotel).ThenInclude(h => h.City)
                .Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<BookingEntities> GetLastBookingPendingForUserAsync(string userId)
        {
            return await context.Bookings
                .Where(b => b.UserId == userId && b.BookingStatus == "Pending")
                .OrderByDescending(b => b.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(BookingEntities booking)
        {
            logger.LogInformation("Before update: " + booking.BookingStatus);
            booking.BookingStatus = "Confirmed";
            await context.SaveChangesAsync();
            logger.LogInformation("After update: " + booking.BookingStatus);
        }
    }
}
