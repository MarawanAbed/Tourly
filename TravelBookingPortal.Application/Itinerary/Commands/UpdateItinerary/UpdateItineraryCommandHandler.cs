using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TravelBookingPortal.Application.Interfaces.Repositories.Itinerary;

namespace TravelBookingPortal.Application.Itinerary.Commands.UpdateItinerary
{
    public class UpdateItineraryCommandHandler(
        IItineraryRepository itineraryRepository,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateItineraryCommand, bool>
    {
        public async Task<bool> Handle(UpdateItineraryCommand request, CancellationToken cancellationToken)
        {
            var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return false; // Unauthorized

            var itinerary = await itineraryRepository.GetByIdAsync(request.ItineraryId);

            if (itinerary == null || itinerary.UserId != userId)
                return false;

            itinerary.Title = request.Title;
            itinerary.StartDate = request.StartDate;
            itinerary.EndDate = request.EndDate;
            itinerary.Notes = request.Notes;

            await itineraryRepository.UpdateAsync(itinerary);
            return true;
        }
    }
}
