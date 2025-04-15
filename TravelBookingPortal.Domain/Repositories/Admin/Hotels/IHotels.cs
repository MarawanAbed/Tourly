

using TravelBookingPortal.Domain.Enitites.HotelEntities;

namespace TravelBookingPortal.Domain.Repositories.Admin.Hotels
{
    public interface IHotels
    {
        Task<IEnumerable<Hotel>> GetAllHotels();
        Task AddHotel(Hotel hotel);
        Task UpdateHotel(Hotel hotel);
        Task DeleteHotel(int id);

    }
}
