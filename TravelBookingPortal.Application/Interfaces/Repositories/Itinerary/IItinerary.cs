using ItineraryEntities = TravelBookingPortal.Domain.Entites.Itinerary.ItineraryEntities;

namespace TravelBookingPortal.Application.Interfaces.Repositories.Itinerary
{
    public interface IItineraryRepository
    {
        Task<List<ItineraryEntities>> GetAllAsync();
        Task<ItineraryEntities> GetByIdAsync(int id);
        Task AddAsync(ItineraryEntities itinerary);
        Task UpdateAsync(ItineraryEntities itinerary);
        Task DeleteAsync(int id);
        Task<List<ItineraryEntities>> GetByUserIdAsync(string userId);
    }
}
