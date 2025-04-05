

using TravelBookingPortal.Domain.Enitites.CityEnities;

namespace TravelBookingPortal.Application.Services.CityService.Abstraction
{
    public interface ICityService
    {
        public Task<IEnumerable<City>> GetAllCitiesAsync();
    }
}
