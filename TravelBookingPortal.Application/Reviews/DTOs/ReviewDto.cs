

namespace TravelBookingPortal.Application.Reviews.Dtos
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int HotelId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public string UserName { get; set; }

        public string UserImage { get; set; }
        public string? HotelName { get; set; }
    }
}
