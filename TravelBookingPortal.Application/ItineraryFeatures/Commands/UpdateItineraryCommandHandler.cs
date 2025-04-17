using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TravelBookingPortal.Domain.Repositories.ItineraryIRepo;

namespace TravelBookingPortal.Application.ItineraryFeatures.Commands
{
    public class UpdateItineraryCommandHandler : IRequestHandler<UpdateItineraryCommand, bool>
    {
        private readonly IItineraryRepository _itineraryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateItineraryCommandHandler(
            IItineraryRepository itineraryRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _itineraryRepository = itineraryRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(UpdateItineraryCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return false; // Unauthorized

            var itinerary = await _itineraryRepository.GetByIdAsync(request.ItineraryId);

            if (itinerary == null || itinerary.UserId != userId)
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
