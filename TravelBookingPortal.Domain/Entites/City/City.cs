using HotelEntities = TravelBookingPortal.Domain.Entites.Hotel.HotelEntities;
namespace TravelBookingPortal.Domain.Entites.City
{
    public class CityEntities
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public string? ImageUrl { get; set; }


        public List<HotelEntities>? Hotels { get; set; } = new List<HotelEntities>();
    }
}
