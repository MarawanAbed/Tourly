using MediatR;
using TravelBookingPortal.Application.ItineraryFeatures.Dtos;
using TravelBookingPortal.Domain.Repositories.ItineraryRepo;
using System.Threading;
using System.Threading.Tasks;

namespace TravelBookingPortal.Application.ItineraryFeatures.Queries
{
    public class GetItineraryByIdQueryHandler : IRequestHandler<GetItineraryByIdQuery, ItineraryDto>
    {
        private readonly IItineraryRepository _itineraryRepository;

        public GetItineraryByIdQueryHandler(IItineraryRepository itineraryRepository)
        {
            _itineraryRepository = itineraryRepository;
        }

        public async Task<ItineraryDto> Handle(GetItineraryByIdQuery request, CancellationToken cancellationToken)
        {
            var itinerary = await _itineraryRepository.GetByIdAsync(request.ItineraryId);
            if (itinerary == null)
                return null;

            return new ItineraryDto
            {
                ItineraryId = itinerary.ItineraryId,
                UserId = itinerary.UserId,
                Title = itinerary.Title,
                StartDate = itinerary.StartDate,
                EndDate = itinerary.EndDate,
                Notes = itinerary.Notes
            };
        }
    }
}
