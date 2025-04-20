using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Application.Interfaces.Seeder.HotelsAndRooms;

using TravelBookingPortal.Domain.Entites.Hotel;
using TravelBookingPortal.Domain.Entites.Room;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Seeder.HotelsAndRooms
{
    public class HotelAndRoomSeeder(TravelBookingPortalDbContext dbContext) : IHotelAndRoomSeeder
    {

        public async Task SeedHotelsAndRooms()
        {
            if (!await dbContext.Hotels.AnyAsync())
            {
                var hotels = new List<HotelEntities>
                {
                    new() {
                        Name = "Grand Hotel",
                        Rooms =
                        [
                            new RoomEntities { RoomNumber = "101", RoomType = "Single", PricePerNight = 100.00m, },
                            new RoomEntities { RoomNumber = "102", RoomType = "Double", PricePerNight = 150.00m, }
                        ]
                        ,
                        CityId = 1
                    },
                    new ()
                    {
                        Name = "Beach Resort",

                        Rooms =
                        [
                                new RoomEntities {  RoomNumber = "201", RoomType = "Suite", PricePerNight = 200.00m, },
                                new RoomEntities {  RoomNumber = "202", RoomType = "Single", PricePerNight = 120.00m }
                        ],
                        CityId=2
                    },
                    new() {
                        Name = "City Inn",
                        Rooms =
                        [
                            new RoomEntities() {  RoomNumber = "301", RoomType = "Double", PricePerNight = 80.00m }
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
