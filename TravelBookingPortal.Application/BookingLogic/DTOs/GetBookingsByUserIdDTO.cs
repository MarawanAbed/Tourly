using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingPortal.Application.BookingLogic.DTOs
{
    class GetBookingsByUserIdDTO
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public decimal PricePerNight { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BookingStatus { get; set; }
        public string HotelName { get; set; }
        public string CityName { get; set; }
    }
}
