using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Enitites.HotelEntities;
using TravelBookingPortal.Domain.Enitites.RoomEntities;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Seeder.HotelsAndRooms
{
    public class HotelAndRoomSeeder(TravelBookingPortalDbContext dbContext) : IHotelAndRoomSeeder
    {

        public async Task SeedHotelsAndRooms()
        {
            if (!await dbContext.Hotels.AnyAsync())
            {
                var hotels = new List<Hotel>
                {
                    new() {
                        Name = "Grand Hotel",
                        Location = "New York",
                        Description = "Luxury hotel in NYC",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/80/Grand_Hotel_1232-38_Broadway.jpg/500px-Grand_Hotel_1232-38_Broadway.jpg",
                        Rooms =
                        [
                            new Room { RoomNumber = "101", RoomType = "Single", PricePerNight = 100.00m, IsAvailable = true },
                            new Room { RoomNumber = "102", RoomType = "Double", PricePerNight = 150.00m, IsAvailable = true }
                        ]
                    },
                    new ()
                    {
                        Name = "Beach Resort",
                        Location = "Miami",
                        Description = "Beachfront resort",
                        ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/square600/646264550.webp?k=6275ee8ccc6104a8d22f8c617771127c95c1b73536832d98a26ebd118bd777ea&o=",
                        Rooms =
                        [
                            new Room {  RoomNumber = "201", RoomType = "Suite", PricePerNight = 200.00m, IsAvailable = true },
                            new Room {  RoomNumber = "202", RoomType = "Single", PricePerNight = 120.00m, IsAvailable = false }
                        ]
                    },
                    new() {
                        Name = "City Inn",
                        Location = "Chicago",
                        Description = "Budget-friendly inn",
                        ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOivi8BcXyAp5ZSh8LruEB7bFiZZmXgoxzVVzCi=s1360-w1360-h1020",
                        Rooms =
                        [
                            new Room() {  RoomNumber = "301", RoomType = "Double", PricePerNight = 80.00m, IsAvailable = true }
                        ]
                    }
                };
                await dbContext.Hotels.AddRangeAsync(hotels);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
