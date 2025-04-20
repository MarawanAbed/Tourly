using MediatR;
using TravelBookingPortal.Application.ItineraryFeatures.Dtos;
using TravelBookingPortal.Application.Interfaces.Repositories.Itinerary;

namespace TravelBookingPortal.Application.Itinerary.Queries.GetAllItineraries
{
    public class GetAllItinerariesQueryHandler(IItineraryRepository itineraryRepository) : IRequestHandler<GetAllItinerariesQuery, List<ItineraryDto>>
    {
        public async Task<List<ItineraryDto>> Handle(GetAllItinerariesQuery request, CancellationToken cancellationToken)
        {
            var itineraries = await itineraryRepository.GetAllAsync();
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
