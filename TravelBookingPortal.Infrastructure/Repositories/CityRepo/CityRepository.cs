
using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Enitites.CityEnities;
using TravelBookingPortal.Domain.Repositories.CityRepo;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Repositories.CityRepo
{
    public class CityRepository : ICityRepository
    {
        private readonly TravelBookingPortalDbContext context;

        public CityRepository(TravelBookingPortalDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await context.Cities.ToListAsync();
        }
    }
}
