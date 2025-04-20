using CityEntities=TravelBookingPortal.Domain.Entites.City.CityEntities;

namespace TravelBookingPortal.Application.Interfaces.Repositories.City
{
    public interface ICityRepository
    {
        public Task<IEnumerable<CityEntities>> GetAllCitiesAsync();

    }
}
