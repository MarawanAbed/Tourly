using HotelEntities=TravelBookingPortal.Domain.Entites.Hotel.HotelEntities;

namespace TravelBookingPortal.Application.Interfaces.Repositories.Admin.Hotel
{
    public interface IHotelsRepository
    {
        Task<IEnumerable<HotelEntities>> GetAllHotels();
        Task AddHotel(HotelEntities hotel);
        Task UpdateHotel(HotelEntities hotel);
        Task DeleteHotel(int id);

    }
}
