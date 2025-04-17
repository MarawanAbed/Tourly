
using AutoMapper;

namespace TravelBookingPortal.Application.RoomLogic.Mapper
{
  public partial  class RoomProfile :Profile
    {
        public RoomProfile()
        {
            GetAvailableRoomListMapper();
            BookingRoomMapper();
            GetRoomByIdMapper();
        }
    }
}
