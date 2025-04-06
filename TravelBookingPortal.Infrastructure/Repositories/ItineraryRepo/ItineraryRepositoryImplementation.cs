using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Repositories.ItineraryRepo;
using TravelBookingPortal.Domain.Enitites.ItineraryEntities;
using TravelBookingPortal.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace TravelBookingPortal.Infrastructure.Repositories.Itinerary
{
    public class ItineraryRepositoryImplementation : IItineraryRepository
    {
        private readonly TravelBookingPortalDbContext _context;

        public ItineraryRepositoryImplementation(TravelBookingPortalDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var itinerary = await _context.Itineraries.FindAsync(id);
            if (itinerary != null)
            {
                _context.Itineraries.Remove(itinerary);
                await _context.SaveChangesAsync();
            }
        }

        async Task<List<Domain.Enitites.ItineraryEntities.Itinerary>> IItineraryRepository.GetAllAsync()
        {
            return await _context.Itineraries.Include(i => i.Items).ToListAsync();
        }

        async Task<Domain.Enitites.ItineraryEntities.Itinerary> IItineraryRepository.GetByIdAsync(int id)
        {
            return await _context.Itineraries.Include(i => i.Items)
                                            .FirstOrDefaultAsync(i => i.ItineraryId == id);
        }

        public async Task AddAsync(Domain.Enitites.ItineraryEntities.Itinerary itinerary)
        {
            await _context.Itineraries.AddAsync(itinerary);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Enitites.ItineraryEntities.Itinerary itinerary)
        {

            _context.Itineraries.Update(itinerary);
            await _context.SaveChangesAsync();
        }
    }
}