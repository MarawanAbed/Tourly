using CityEntities=TravelBookingPortal.Domain.Entites.City.CityEntities;

namespace TravelBookingPortal.Application.Interfaces.Repositories.Admin.City
{
    public interface ICityRepository
    {

        Task<IEnumerable<CityEntities>> GetAllCities();
        Task AddCity(CityEntities city);
        Task UpdateCity(CityEntities city);
        Task DeleteCity(int id);
    }
}
