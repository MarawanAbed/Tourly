using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Application.RoomLogic.Queries.RoomService.Abstraction;
using TravelBookingPortal.Domain.Enitites.RoomEntities;
using TravelBookingPortal.Domain.Repositories.RoomRepo;

namespace TravelBookingPortal.Application.RoomLogic.Queries.RoomService.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(string city, DateTime checkIn, DateTime checkOut,string roomType)
        {
           return await roomRepository.GetRoomByCityAndAvailabilityAsync(city, checkIn, checkOut,roomType);
        }
    }
}
