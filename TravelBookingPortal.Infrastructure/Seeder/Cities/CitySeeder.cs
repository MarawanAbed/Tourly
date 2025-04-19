
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
                    new() { Name = "New York" },
                    new() { Name = "Los Angeles" },
                    new() { Name = "Chicago" },
                    new() { Name = "Houston" },


                };
                await dbContext.Cities.AddRangeAsync(cities);
                await dbContext.SaveChangesAsync();

            }
        }
    }
}
