using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingPortal.Application.RoomLogic.Commands.RoomService.Abstraction
{
   public interface IRoomServiceCommands 
    {
        public Task BookRoomAsync(string userId, int roomId, DateTime checkIn, DateTime checkOut,decimal totalPrice);
    }
}
