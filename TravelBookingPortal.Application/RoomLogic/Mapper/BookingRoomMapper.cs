using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Application.RoomLogic.Dtos;
using TravelBookingPortal.Domain.Enitites.BookingEntities;

namespace TravelBookingPortal.Application.RoomLogic.Mapper
{
   public partial class RoomProfile
    {
        public void BookingRoomMapper()
        {
            CreateMap<Booking, BookingRoomDTO>();
        }
    }
}
