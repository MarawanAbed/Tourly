using MediatR;
using System.Security.Claims;
using TravelBookingPortal.Domain.Enitites.ItineraryEntities;
using TravelBookingPortal.Domain.Repositories.ItineraryIRepo;
using Microsoft.AspNetCore.Http;

namespace TravelBookingPortal.Application.ItineraryFeatures.Commands
{
    public class CreateItineraryCommandHandler : IRequestHandler<CreateItineraryCommand, int>
    {
        private readonly IItineraryRepository _itineraryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateItineraryCommandHandler(IItineraryRepository itineraryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _itineraryRepository = itineraryRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Handle(CreateItineraryCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new Exception("User ID is not found in the token.");

            var itinerary = new Itinerary
            {
                UserId = userId,
                Title = request.Title,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Notes = request.Notes
            };

            await _itineraryRepository.AddAsync(itinerary);
            return itinerary.ItineraryId;
        }
    }
}
