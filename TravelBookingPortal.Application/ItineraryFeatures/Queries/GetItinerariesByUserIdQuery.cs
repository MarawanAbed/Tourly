using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Enitites.ItineraryEntities;

namespace TravelBookingPortal.Application.ItineraryFeatures.Queries
{
    public class GetItinerariesByUserIdQuery : IRequest<List<Itinerary>>
    {
        public string UserId { get; set; }

        public GetItinerariesByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
