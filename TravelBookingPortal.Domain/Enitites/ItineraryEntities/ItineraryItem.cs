namespace TravelBookingPortal.Domain.Enitites.ItineraryEntities
{
    public class ItineraryItem
    {
        public int ItemId { get; set; }
        public int ItineraryId { get; set; }
        public string Description { get; set; }
        public DateTime? DateTime { get; set; }

        public Itinerary? Itinerary { get; set; }
    }
}
