

using Microsoft.EntityFrameworkCore;
using HotelEntities = TravelBookingPortal.Domain.Entites.Hotel.HotelEntities;
using TravelBookingPortal.Persistence.Persistence;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Hotel;

namespace TravelBookingPortal.Persistence.Repositories.Admin.Hotel;

public class HotelRepository(TravelBookingPortalDbContext _context) : IHotelsRepository
{
    public async Task AddHotel(HotelEntities hotel)
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

    public async Task<IEnumerable<HotelEntities>> GetAllHotels()
    {
        return await _context.Hotels
            .Include(h => h.City)
            .ToListAsync();
    }


    public async Task UpdateHotel(HotelEntities hotel)
    {
        var existingHotel = await _context.Hotels.FindAsync(hotel.HotelId);
        if (existingHotel != null)
        {
            if (hotel.ImageUrl != null)
            {
                existingHotel.ImageUrl = hotel.ImageUrl;
            }
            else
            {
                existingHotel.ImageUrl = existingHotel.ImageUrl;
            }
            existingHotel.Name = hotel.Name;
            existingHotel.CityId = existingHotel.CityId;
            await _context.SaveChangesAsync();
        }
    }
}
