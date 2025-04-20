using BookingEntity = TravelBookingPortal.Domain.Entites.Booking.BookingEntities;

namespace TravelBookingPortal.Application.Interfaces.Repositories.Admin.Booking;

public interface IBookingRepository
{

    Task<IEnumerable<BookingEntity>> GetAllBookings();
    Task AddBooking(BookingEntity booking);
    Task UpdateBooking(BookingEntity booking);
    Task DeleteBooking(int id);

}
