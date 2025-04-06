using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Enitites.HotelEntities;

namespace TravelBookingPortal.Application.RoomLogic.Dtos
{
    class GetOneRoomDTO
    {
        
        public string HotelName { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }


    }
}
