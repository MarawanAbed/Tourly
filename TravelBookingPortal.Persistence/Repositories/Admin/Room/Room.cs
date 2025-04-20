

using Microsoft.EntityFrameworkCore;
using RoomEntities = TravelBookingPortal.Domain.Entites.Room.RoomEntities;
using TravelBookingPortal.Persistence.Persistence;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Room;

namespace TravelBookingPortal.Persistence.Repositories.Admin.Room
{
    public class RoomRepository(TravelBookingPortalDbContext _context) : IRoomRepository
    {
        public async Task AddRoom(RoomEntities room)
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

        public async Task<IEnumerable<RoomEntities>> GetAllRooms()
        {
            return await _context.Rooms
                .Include(r => r.Hotel)
                .ToListAsync();
        }

        public async Task UpdateRoom(RoomEntities room)
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
                existingRoom.RoomType = room.RoomType;
                existingRoom.RoomNumber = existingRoom.RoomNumber;
                existingRoom.HotelId = existingRoom.HotelId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
