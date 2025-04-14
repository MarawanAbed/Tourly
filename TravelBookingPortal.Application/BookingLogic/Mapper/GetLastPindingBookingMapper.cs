using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Application.BookingLogic.DTOs;
using TravelBookingPortal.Application.CityLogic.Dtos;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Enitites.CityEnities;

namespace TravelBookingPortal.Application.BookingLogic.Mapper
{
  public partial class BookingProfile
    {
        public void GetLastPindingBookingMapper()
        {
            CreateMap<Booking, GetLastBookingByUserIdDTO>();
        }
    }
}
