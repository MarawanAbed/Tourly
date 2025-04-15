

using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Enitites.HotelEntities;
using TravelBookingPortal.Domain.Repositories.Admin.Hotels;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Repositories.Admin.Hotels;

public class Hotels(TravelBookingPortalDbContext _context) : IHotels
{
    public async Task AddHotel(Hotel hotel)
    {
        await _context.Hotels.AddAsync(hotel);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHotel(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel != null)
        {
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Hotel>> GetAllHotels()
    {
        return await _context.Hotels
            .Include(h => h.City)
            .ToListAsync();
    }


    public async Task UpdateHotel(Hotel hotel)
    {
        var existingHotel = await _context.Hotels.FindAsync(hotel.HotelId);
        if (existingHotel != null)
        {
            existingHotel.Name = hotel.Name;
            existingHotel.Description = hotel.Description;
            existingHotel.ImageUrl = hotel.ImageUrl;
            existingHotel.CityId = hotel.CityId;
            await _context.SaveChangesAsync();
        }
    }
}
