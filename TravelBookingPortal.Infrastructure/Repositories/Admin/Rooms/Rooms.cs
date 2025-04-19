

using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Enitites.HotelEntities;
using TravelBookingPortal.Domain.Enitites.RoomEntities;
using TravelBookingPortal.Domain.Repositories.Admin.Rooms;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Repositories.Admin.Rooms
{
    public class Rooms(TravelBookingPortalDbContext _context) : IRooms
    {
        public async Task AddRoom(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _context.Rooms
                .Include(r => r.Hotel)
                .ToListAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            var existingRoom = await _context.Rooms.FindAsync(room.RoomId);
            if (existingRoom != null)
            {
                if (room.ImageUrl != null)
                {
                    existingRoom.ImageUrl = room.ImageUrl;
                }
                else
                {
                    existingRoom.ImageUrl = existingRoom.ImageUrl;
                }
                existingRoom.PricePerNight = room.PricePerNight;
                existingRoom.IsAvailable = existingRoom.IsAvailable;
                existingRoom.RoomType = room.RoomType;
                existingRoom.RoomNumber = existingRoom.RoomNumber;
                existingRoom.HotelId = existingRoom.HotelId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
