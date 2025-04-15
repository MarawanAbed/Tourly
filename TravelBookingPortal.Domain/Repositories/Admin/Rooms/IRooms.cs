
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Domain.Repositories.Admin.Rooms
{
    public interface IRooms
    {

        Task<IEnumerable<Room>> GetAllRooms();
        Task AddRoom(Room room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(int id);
    }
}
