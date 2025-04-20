
using ItineraryEntities = TravelBookingPortal.Domain.Entites.Itinerary.ItineraryEntities;
using TravelBookingPortal.Persistence.Persistence;

using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Application.Interfaces.Repositories.Itinerary;

namespace TravelBookingPortal.Persistence.Repositories.Itinerary
{
    public class ItineraryRepository(TravelBookingPortalDbContext context) : IItineraryRepository
    {
        public async Task DeleteAsync(int id)
        {
            var itinerary = await context.Itineraries.FindAsync(id);
            if (itinerary != null)
            {
                context.Itineraries.Remove(itinerary);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<ItineraryEntities>> GetAllAsync()
        {
            return await context.Itineraries.ToListAsync();
        }

        public async Task<ItineraryEntities> GetByIdAsync(int id)
        {
            return await context.Itineraries
                                            .FirstOrDefaultAsync(i => i.ItineraryId == id);
        }

        public async Task AddAsync(ItineraryEntities itinerary)
        {
            await context.Itineraries.AddAsync(itinerary);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ItineraryEntities itinerary)
        {

            context.Itineraries.Update(itinerary);
            await context.SaveChangesAsync();
        }

        public async Task<List<ItineraryEntities>> GetByUserIdAsync(string userId)
        {
            return await context.Itineraries
                .Where(i => i.UserId == userId)

                .ToListAsync();
        }
    }
}