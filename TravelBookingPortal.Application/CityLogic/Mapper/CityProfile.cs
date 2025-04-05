using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TravelBookingPortal.Application.CityLogic.Mapper
{
  public partial  class CityProfile :Profile
    {
        public CityProfile()
        {
            CitiesListMapping();
        }
    }
}
