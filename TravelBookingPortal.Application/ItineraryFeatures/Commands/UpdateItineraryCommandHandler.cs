using MediatR;
using TravelBookingPortal.Domain.Repositories.ItineraryIRepo;

namespace TravelBookingPortal.Application.ItineraryFeatures.Commands
{
    public class UpdateItineraryCommandHandler : IRequestHandler<UpdateItineraryCommand, bool>
    {
        private readonly IItineraryRepository _itineraryRepository;

        public UpdateItineraryCommandHandler(IItineraryRepository itineraryRepository)
        {
            _itineraryRepository = itineraryRepository;
        }

        public async Task<bool> Handle(UpdateItineraryCommand request, CancellationToken cancellationToken)
        {
            var itinerary = await _itineraryRepository.GetByIdAsync(request.ItineraryId);
            if (itinerary == null || itinerary.UserId != request.UserId)
                return false;

            itinerary.Title = request.Title;
            itinerary.StartDate = request.StartDate;
            itinerary.EndDate = request.EndDate;
            itinerary.Notes = request.Notes;

            await _itineraryRepository.UpdateAsync(itinerary);
            return true;
        }
    }
}
