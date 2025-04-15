using TravelBookingPortal.Domain.Enitites.HotelEntities;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Domain.Enitites.ReviewEntities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        public int HotelId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser? User { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
