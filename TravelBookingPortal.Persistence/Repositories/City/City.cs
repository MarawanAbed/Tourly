using Microsoft.EntityFrameworkCore;
using CityEntities = TravelBookingPortal.Domain.Entites.City.CityEntities;
using TravelBookingPortal.Application.Interfaces.Repositories.City;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Repositories.City
{
    public class CityRepository(TravelBookingPortalDbContext Context) : ICityRepository
    {

        public async Task<IEnumerable<CityEntities>> GetAllCitiesAsync()
        {
            return await Context.Cities.ToListAsync();
        }
    }
}
