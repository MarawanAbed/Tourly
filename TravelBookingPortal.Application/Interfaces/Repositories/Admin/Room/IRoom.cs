using RoomEntities = TravelBookingPortal.Domain.Entites.Room.RoomEntities;

namespace TravelBookingPortal.Application.Interfaces.Repositories.Admin.Room
{
    public interface IRoomRepository
    {

        Task<IEnumerable<RoomEntities>> GetAllRooms();
        Task AddRoom(RoomEntities room);
        Task UpdateRoom(RoomEntities room);
        Task DeleteRoom(int id);
    }
}
