
using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Seeder.Bookings
{
    public class BookingSeeder(TravelBookingPortalDbContext dbContext,
        UserManager<ApplicationUser> userManager) : IBookingSeeder
    {

        public async Task SeedBookings()
        {
            if (!dbContext.Bookings.Any())
            {
                var john = await userManager.FindByEmailAsync("john.doe@example.com");
                var jane = await userManager.FindByEmailAsync("jane.smith@example.com");

                var bookings = new List<Booking>
                {
                    new() {
                        UserId = john.Id,
                        RoomId = 1,
                        CheckInDate = DateTime.UtcNow.AddDays(1),
                        CheckOutDate = DateTime.UtcNow.AddDays(3),
                        TotalPrice = 200.00m,
                        BookingStatus = "Confirmed",
                        CreatedAt = DateTime.UtcNow,
                        PaymentId = "pi_001"
                    },
                    new() {
                        UserId = jane.Id,
                        RoomId = 3,
                        CheckInDate = DateTime.UtcNow.AddDays(5),
                        CheckOutDate = DateTime.UtcNow.AddDays(7),
                        TotalPrice = 400.00m,
                        BookingStatus = "Pending",
                        CreatedAt = DateTime.UtcNow
                    }
                };

                await dbContext.Bookings.AddRangeAsync(bookings);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
