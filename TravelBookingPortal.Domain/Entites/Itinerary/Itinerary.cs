using TravelBookingPortal.Domain.Entites.User;
namespace TravelBookingPortal.Domain.Entites.Itinerary
{
    public class ItineraryEntities
    {
        public int ItineraryId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }

        public ApplicationUser? User { get; set; }

    }
}
