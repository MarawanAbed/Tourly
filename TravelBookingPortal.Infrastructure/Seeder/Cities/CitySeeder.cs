
using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Enitites.CityEnities;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Seeder.Cities
{
    public class CitySeeder(TravelBookingPortalDbContext dbContext) : ICitySeeder
    {

        public async Task SeedCities()
        {

            if (!await dbContext.Hotels.AnyAsync())
            {
                var cities = new List<City>
                {
                    new() { Name = "New York" ,ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/8/80/Grand_Hotel_1232-38_Broadway.jpg/500px-Grand_Hotel_1232-38_Broadway.jpg"},
                    new() { Name = "Los Angeles" , ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/e/e3/Los_Angeles_City_Hall_2013_%28cropped%29.jpg/330px-Los_Angeles_City_Hall_2013_%28cropped%29.jpg" },
                    new() { Name = "Chicago" , ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3d/Chicago_Board_Of_Trade_Building.jpg/330px-Chicago_Board_Of_Trade_Building.jpg" },
                    new() { Name = "Houston" , ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/Texas_medical_center.jpg/330px-Texas_medical_center.jpg" },


                };
                await dbContext.Cities.AddRangeAsync(cities);
                await dbContext.SaveChangesAsync();

            }
        }
    }
}
