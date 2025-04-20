using RoomEntities = TravelBookingPortal.Domain.Entites.Room.RoomEntities;

namespace TravelBookingPortal.Application.Interfaces.Repositories.Room
{
    public interface IRoomRepository
    {
        public Task<IEnumerable<RoomEntities>> GetRoomByCityAndAvailabilityAsync(string city, DateTime checkIn, DateTime checkOut, string roomType);
        public Task AddBookingAsync(string UserId, int RoomId, DateTime CheckIn, DateTime CheckOut, decimal TotalPrice);
        public Task<RoomEntities> GetRoomByIdAsync(int roomId);
    }
}
