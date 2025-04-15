
using TravelBookingPortal.Domain.Enitites.CityEnities;

namespace TravelBookingPortal.Domain.Repositories.Admin.Cities
{
    public interface ICities
    {

        Task<IEnumerable<City>> GetAllCities();
        Task AddCity(City city);
        Task UpdateCity(City city);
        Task DeleteCity(int id);
    }
}
