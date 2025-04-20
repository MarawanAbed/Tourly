using HotelEntities=TravelBookingPortal.Domain.Entites.Hotel.HotelEntities;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Domain.Entites.Review
{
    public class ReviewEntities
    {
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        public int HotelId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser? User { get; set; }
        public HotelEntities? Hotel { get; set; }
    }
}
