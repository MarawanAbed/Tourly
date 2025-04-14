using MediatR;
using TravelBookingPortal.Application.ItineraryFeatures.Dtos;

using System.Collections.Generic;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Repositories.ItineraryIRepo;

namespace TravelBookingPortal.Application.ItineraryFeatures.Queries
{
    public class GetAllItinerariesQueryHandler : IRequestHandler<GetAllItinerariesQuery, List<ItineraryDto>>
    {
        private readonly IItineraryRepository _itineraryRepository;

        public GetAllItinerariesQueryHandler(IItineraryRepository itineraryRepository)
        {
            _itineraryRepository = itineraryRepository;
        }

        public async Task<List<ItineraryDto>> Handle(GetAllItinerariesQuery request, CancellationToken cancellationToken)
        {
            var itineraries = await _itineraryRepository.GetAllAsync();
            return itineraries.Select(itinerary => new ItineraryDto
            {
                ItineraryId = itinerary.ItineraryId,
                UserId = itinerary.UserId,
                Title = itinerary.Title,
                StartDate = itinerary.StartDate,
                EndDate = itinerary.EndDate,
                Notes = itinerary.Notes
            }).ToList();
        }
    }
}
