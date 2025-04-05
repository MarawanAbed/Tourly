using TravelBookingPortal.Domain.Enitites.CityEnities;

namespace TravelBookingPortal.Application.CityLogic.Queries.CityService.Abstraction
{
    public interface ICityService
    {
        public Task<IEnumerable<City>> GetAllCitiesAsync();
    }
}
