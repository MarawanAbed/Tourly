using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TravelBookingPortal.Application.BookingLogic.Mapper
{
  public partial  class BookingProfile:Profile
    {
        public BookingProfile()
        {
            GetLastPindingBookingMapper();
            GetBookingsByUserIdMapper();
        }
    }
}
