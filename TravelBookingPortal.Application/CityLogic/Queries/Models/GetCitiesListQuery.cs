using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Application.CityLogic.Dtos;

namespace TravelBookingPortal.Application.CityLogic.Queries.Models
{
   public class GetCitiesListQuery :IRequest<IEnumerable<GetCitiesDTO>>
    {
        

    }
    
}
