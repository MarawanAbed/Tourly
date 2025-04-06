using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Application.RoomLogic.Dtos;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Application.RoomLogic.Mapper
{
   public partial class RoomProfile
    {
        public void GetRoomByIdMapper()
        {
            CreateMap<Room, GetOneRoomDTO>().ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Hotel.City.Name))
                ;
        }
    }
}
