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
                        Description = "Luxury hotel in NYC",
                        Rooms =
                        [
                            new Room { RoomNumber = "101", RoomType = "Single", PricePerNight = 100.00m, },
                            new Room { RoomNumber = "102", RoomType = "Double", PricePerNight = 150.00m, }
                        ]
                        ,
                        CityId = 1
                    },
                    new ()
                    {
                        Name = "Beach Resort",
                        Description = "Beachfront resort",
                       
                        Rooms =
                        [
                                new Room {  RoomNumber = "201", RoomType = "Suite", PricePerNight = 200.00m, },
                                new Room {  RoomNumber = "202", RoomType = "Single", PricePerNight = 120.00m }
                        ],
                        CityId=2
                    },
                    new() {
                        Name = "City Inn",
                        Description = "Budget-friendly inn",
                        Rooms =
                        [
                            new Room() {  RoomNumber = "301", RoomType = "Double", PricePerNight = 80.00m }
                        ],
                        CityId=3
                    }
                };
                await dbContext.Hotels.AddRangeAsync(hotels);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
