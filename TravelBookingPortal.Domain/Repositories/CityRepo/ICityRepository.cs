
using TravelBookingPortal.Domain.Enitites.CityEnities;

namespace TravelBookingPortal.Domain.Repositories.CityRepo
{
     public interface ICityRepository
    {
        public Task<IEnumerable<City>> GetAllCitiesAsync();

    }
}
