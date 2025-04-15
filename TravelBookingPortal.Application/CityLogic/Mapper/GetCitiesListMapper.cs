
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
