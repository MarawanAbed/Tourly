using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Application.RoomLogic.Queries.RoomService.Abstraction
{
   public interface IRoomService
    {
        public Task<IEnumerable<Room>> GetAvailableRoomsAsync(string city, DateTime checkIn, DateTime checkOut,string roomType);
    }
}
