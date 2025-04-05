using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Application.Services.CityService.Abstraction;
using TravelBookingPortal.Domain.Enitites.CityEnities;
using TravelBookingPortal.Domain.Repositories.CityRepo;

namespace TravelBookingPortal.Application.Services.CityService.Implementation
{
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await cityRepository.GetAllCitiesAsync();
        }

        
    }
}
