using TravelBookingPortal.Application.Interfaces.Seeder.Bookings;
using TravelBookingPortal.Application.Interfaces.Seeder.Cities;
using TravelBookingPortal.Application.Interfaces.Seeder.HotelsAndRooms;
using TravelBookingPortal.Application.Interfaces.Seeder.ItinerariesAndItems;
using TravelBookingPortal.Application.Interfaces.Seeder.Reviews;
using TravelBookingPortal.Application.Interfaces.Seeder.Roles;
using TravelBookingPortal.Application.Interfaces.Seeder.Travel;
using TravelBookingPortal.Application.Interfaces.Seeder.Users;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Seeder.Travel
{
    public class TravelBookingSeeder(
        TravelBookingPortalDbContext dbContext,
        IRoleSeeder roleSeeder,
        IUserSeeder userSeeder,
        IHotelAndRoomSeeder hotelSeeder,
        IBookingSeeder bookingSeeder,
        IItineraryAndItemsSeeder itinerarySeeder,
        IReviewSeeder reviewSeeder,
        ICitySeeder citySeeder
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
                //Seed Cities
                await citySeeder.SeedCities();

                // Seed Hotels and Rooms
                await hotelSeeder.SeedHotelsAndRooms();


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