using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Repositories.BookingRepo;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Repositories.Bookingrepo
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TravelBookingPortalDbContext _context;
        private readonly ILogger<BookingRepository> logger;

        public BookingRepository(TravelBookingPortalDbContext context, ILogger<BookingRepository> _logger)
        {
            _context = context;
            logger = _logger;
        }

        public async Task DeleteBookingForUserAsync(int bookingId)
        {
           _context.Bookings.Remove(new Booking { BookingId = bookingId });
            await _context.SaveChangesAsync();
            

        }

        public async Task<Booking> GetBookingByIdAsync(int id)

        {
            var booking = await _context.Bookings
                    .Where(b => b.BookingId == id)
                    .FirstOrDefaultAsync();


            return booking;
            
            
            

            }

        public async Task<IEnumerable<Booking>> GetBookingByUserIdAsync(string userId)
        {
            return await _context.Bookings
                .Include(b=>b.Room).ThenInclude(c=>c.Hotel).ThenInclude(h=>h.City)
                .Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<Booking> GetLastBookingPendingForUserAsync(string userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId && b.BookingStatus == "Pending")
                .OrderByDescending(b => b.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Booking booking)
        {
            logger.LogInformation("Before update: " + booking.BookingStatus);
            booking.BookingStatus = "Confirmed";
            await _context.SaveChangesAsync();
            logger.LogInformation("After update: " + booking.BookingStatus);
        }
    }
    }
