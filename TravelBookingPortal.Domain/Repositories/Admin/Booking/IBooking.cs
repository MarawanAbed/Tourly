
using BookingEntity = TravelBookingPortal.Domain.Enitites.BookingEntities; 

namespace TravelBookingPortal.Domain.Repositories.Admin.Booking;

public interface IBooking
{

    Task<IEnumerable<BookingEntity.Booking>> GetAllBookings(int hotelId);
    Task AddBooking(BookingEntity.Booking booking);
    Task UpdateBooking(BookingEntity.Booking booking);
    Task DeleteBooking(int id);

}
