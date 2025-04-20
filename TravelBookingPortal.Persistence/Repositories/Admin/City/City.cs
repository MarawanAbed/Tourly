
using Microsoft.EntityFrameworkCore;
using CityEntity = TravelBookingPortal.Domain.Entites.City.CityEntities;
using TravelBookingPortal.Persistence.Persistence;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.City;

namespace TravelBookingPortal.Persistence.Repositories.Admin.City
{
    public class CityRepository(TravelBookingPortalDbContext _context) : ICityRepository
    {
        public async Task AddCity(CityEntity city)
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

        public async Task<IEnumerable<CityEntity>> GetAllCities()
        {
            return await _context.Cities
                .ToListAsync();
        }

        public async Task UpdateCity(CityEntity city)
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
