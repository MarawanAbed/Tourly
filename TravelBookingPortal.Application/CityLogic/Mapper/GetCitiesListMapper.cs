using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TravelBookingPortal.Application.CityLogic.Dtos;
using TravelBookingPortal.Domain.Enitites.CityEnities;
namespace TravelBookingPortal.Application.CityLogic.Mapper
{
   public partial class CityProfile
    {
        public void CitiesListMapping()
        {
            CreateMap<City, GetCitiesDTO>();
               
        }
    }
}
