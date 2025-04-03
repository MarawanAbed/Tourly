
using TravelBookingPortal.Infrastructure.DbContext;
using TravelBookingPortal.Infrastructure.Seeder.Bookings;
using TravelBookingPortal.Infrastructure.Seeder.HotelsAndRooms;
using TravelBookingPortal.Infrastructure.Seeder.ItinerariesAndItems;
using TravelBookingPortal.Infrastructure.Seeder.Preferences;
using TravelBookingPortal.Infrastructure.Seeder.Reviews;
using TravelBookingPortal.Infrastructure.Seeder.Roles;
using TravelBookingPortal.Infrastructure.Seeder.Users;

namespace TravelBookingPortal.Infrastructure.Seeder
{
    public class TravelBookingSeeder(
        TravelBookingPortalDbContext dbContext,
        IRoleSeeder roleSeeder,
        IUserSeeder userSeeder,
        IHotelAndRoomSeeder hotelSeeder,
        IPreferenceSeeder preferenceSeeder,
        IBookingSeeder bookingSeeder,
        IItineraryAndItemsSeeder itinerarySeeder,
        IReviewSeeder reviewSeeder
        ) : ITravelBookingSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                // Seed Roles
                await roleSeeder.SeedRoles();

                // Seed Users
                await userSeeder.SeedUsers();

                // Seed Hotels and Rooms
                await hotelSeeder.SeedHotelsAndRooms();

                // Seed User Preferences
                await preferenceSeeder.SeedPreferences();

                // Seed Bookings
                await bookingSeeder.SeedBookings();

                // Seed Itineraries and Items
                await itinerarySeeder.SeedItinerariesAndItems();

                // Seed Reviews
                await reviewSeeder.SeedReviews();


            }
        }
    }
}