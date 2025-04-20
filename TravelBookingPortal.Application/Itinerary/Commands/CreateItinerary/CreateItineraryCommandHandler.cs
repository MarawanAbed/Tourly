using MediatR;
using System.Security.Claims;
using ItineraryEntities=TravelBookingPortal.Domain.Entites.Itinerary.ItineraryEntities;
using Microsoft.AspNetCore.Http;
using TravelBookingPortal.Application.Interfaces.Repositories.Itinerary;

namespace TravelBookingPortal.Application.Itinerary.Commands.CreateItinerary
{
    public class CreateItineraryCommandHandler(IItineraryRepository itineraryRepository, IHttpContextAccessor httpContextAccessor) : IRequestHandler<CreateItineraryCommand, int>
    {
        public async Task<int> Handle(CreateItineraryCommand request, CancellationToken cancellationToken)
        {
            var userId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new Exception("User ID is not found in the token.");

            var itinerary = new ItineraryEntities
            {
                UserId = userId,
                Title = request.Title,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Notes = request.Notes
            };

            await itineraryRepository.AddAsync(itinerary);
            return itinerary.ItineraryId;
        }
    }
}
