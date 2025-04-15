using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Enitites.ItineraryEntities;
using TravelBookingPortal.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Repositories.ItineraryIRepo;

namespace TravelBookingPortal.Infrastructure.Repositories.ItineraryRepo
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

        public async Task<List<Itinerary>> GetAllAsync()
        {
            return await _context.Itineraries.Include(i => i.Items).ToListAsync();
        }

        public async Task<Itinerary> GetByIdAsync(int id)
        {
            return await _context.Itineraries.Include(i => i.Items)
                                            .FirstOrDefaultAsync(i => i.ItineraryId == id);
        }

        public async Task AddAsync(Itinerary itinerary)
        {
            await _context.Itineraries.AddAsync(itinerary);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Itinerary itinerary)
        {

            _context.Itineraries.Update(itinerary);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Itinerary>> GetByUserIdAsync(string userId)
        {
            return await _context.Itineraries
                .Where(i => i.UserId == userId)
                .Include(i => i.Items)
                .ToListAsync();
        }
    }
}