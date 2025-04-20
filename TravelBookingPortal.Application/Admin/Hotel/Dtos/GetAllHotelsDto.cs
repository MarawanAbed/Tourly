namespace TravelBookingPortal.Application.Admin.Hotel.Dtos
{
    public class GetAllHotelsDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CityName { get; set; }
    }
}
