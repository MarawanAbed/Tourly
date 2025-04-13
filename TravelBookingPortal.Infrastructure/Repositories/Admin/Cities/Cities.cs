
using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Enitites.CityEnities;
using TravelBookingPortal.Domain.Repositories.Admin.Cities;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Repositories.Admin.Cities
{
    public class Cities(TravelBookingPortalDbContext _context) : ICities
    {
        public async Task AddCity(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _context.Cities
                .ToListAsync();
        }

        public async Task UpdateCity(City city)
        {
            var existingCity = await _context.Cities.FindAsync(city.CityId);
            if (existingCity != null)
            {
                existingCity.Name = city.Name;
                existingCity.ImageUrl = city.ImageUrl;
                await _context.SaveChangesAsync();
            }
        }
    }
}
