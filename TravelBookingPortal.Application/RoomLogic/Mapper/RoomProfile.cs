using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TravelBookingPortal.Application.RoomLogic.Mapper
{
  public partial  class RoomProfile :Profile
    {
        public RoomProfile()
        {
            GetAvailableRoomListMapper();
            BookingRoomMapper();
        }
    }
}
