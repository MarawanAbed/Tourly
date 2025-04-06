using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Enitites;
namespace TravelBookingPortal.Domain.Enitites.ItineraryEntities
{
    public class Itinerary
    {
        public int ItineraryId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }

        public ApplicationUser User { get; set; }
        public List<ItineraryItem> Items { get; set; }
    }
}
