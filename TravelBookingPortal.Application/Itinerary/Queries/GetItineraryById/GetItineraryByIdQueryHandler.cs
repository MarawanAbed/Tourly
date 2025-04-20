using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Itinerary;
using TravelBookingPortal.Application.ItineraryFeatures.Dtos;



namespace TravelBookingPortal.Application.Itinerary.Queries.GetItineraryById
{
    public class GetItineraryByIdQueryHandler(IItineraryRepository itineraryRepository) : IRequestHandler<GetItineraryByIdQuery, ItineraryDto>  // تغيير List<ItineraryDto> إلى ItineraryDto
    {
        public async Task<ItineraryDto> Handle(GetItineraryByIdQuery request, CancellationToken cancellationToken)
        {
            var itinerary = await itineraryRepository.GetByIdAsync(request.ItineraryId);  // استخدام GetByIdAsync للبحث عن مخطط واحد
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
