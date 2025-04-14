
using TravelBookingPortal.Application.RoomLogic.Dtos;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Application.RoomLogic.Mapper
{
   public partial class RoomProfile
    {
        public void  GetAvailableRoomListMapper()
        {

            CreateMap<Room, GetRoomsDTO>()
           .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name));
           
        }

    }
}
