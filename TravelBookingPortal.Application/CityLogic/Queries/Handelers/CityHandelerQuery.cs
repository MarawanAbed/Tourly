using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.CityLogic.Dtos;

using TravelBookingPortal.Application.CityLogic.Queries.Models;
using TravelBookingPortal.Domain.Repositories.CityRepo;


namespace TravelBookingPortal.Application.CityLogic.Queries.Handelers
{
    public class CityHandelerQuery : IRequestHandler<GetCitiesListQuery, IEnumerable<GetCitiesDTO>>
    {
        private readonly ICityRepository cityRepository;
        private readonly IMapper mapper;

        public CityHandelerQuery(ICityRepository cityRepository,IMapper mapper)
        {
            this.cityRepository = cityRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<GetCitiesDTO>> Handle(GetCitiesListQuery request, CancellationToken cancellationToken)
        {
            var CityList = await cityRepository.GetAllCitiesAsync();
            var cityListMapper = mapper.Map<IEnumerable<GetCitiesDTO>>(CityList);
            return cityListMapper;
        }
    }
}
