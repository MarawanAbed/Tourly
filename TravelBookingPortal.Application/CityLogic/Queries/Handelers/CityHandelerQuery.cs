using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.CityLogic.Dtos;
using TravelBookingPortal.Application.CityLogic.Queries.CityService.Abstraction;
using TravelBookingPortal.Application.CityLogic.Queries.Models;


namespace TravelBookingPortal.Application.CityLogic.Queries.Handelers
{
    public class CityHandelerQuery : IRequestHandler<GetCitiesListQuery, IEnumerable<GetCitiesDTO>>
    {
        private readonly ICityService cityService;
        private readonly IMapper mapper;

        public CityHandelerQuery(ICityService cityService,IMapper mapper)
        {
            this.cityService = cityService;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<GetCitiesDTO>> Handle(GetCitiesListQuery request, CancellationToken cancellationToken)
        {
            var CityList = await cityService.GetAllCitiesAsync();
            var cityListMapper = mapper.Map<IEnumerable<GetCitiesDTO>>(CityList);
            return cityListMapper;
        }
    }
}
