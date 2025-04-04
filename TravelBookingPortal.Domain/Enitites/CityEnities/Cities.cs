
using TravelBookingPortal.Domain.Enitites.HotelEntities;

namespace TravelBookingPortal.Domain.Enitites.CityEnities
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }


        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
