using TravelBookingPortal.Domain.Enitites.ItineraryEntities;

namespace TravelBookingPortal.Domain.Repositories.ItineraryRepo
{
    public interface IItineraryRepository
    {
        Task<List<Itinerary>> GetAllAsync();
        Task<Itinerary> GetByIdAsync(int id);
        Task AddAsync(Itinerary itinerary);
        Task UpdateAsync(Itinerary itinerary);
        Task DeleteAsync(int id);
        Task<List<Itinerary>> GetByUserIdAsync(string userId);  // تعديل هنا للبحث عن الرحلات بناءً على UserId
    }
}
