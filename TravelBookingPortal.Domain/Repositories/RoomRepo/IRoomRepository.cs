
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Domain.Repositories.RoomRepo
{
    public interface IRoomRepository
    {
        public Task<IEnumerable<Room>> GetRoomByCityAndAvailabilityAsync(string city, DateTime checkIn, DateTime checkOut, string roomType);
        public Task AddBookingAsync(string UserId, int RoomId, DateTime CheckIn, DateTime CheckOut, decimal TotalPrice);
        public Task<Room> GetRoomByIdAsync(int roomId);
    }
}
