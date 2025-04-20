
using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Application.Interfaces.Seeder.Cities;
using TravelBookingPortal.Domain.Entites.City;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Seeder.Cities
{
    public class CitySeeder(TravelBookingPortalDbContext dbContext) : ICitySeeder
    {

        public async Task SeedCities()
        {

            if (!await dbContext.Hotels.AnyAsync())
            {
                var cities = new List<CityEntities>
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
