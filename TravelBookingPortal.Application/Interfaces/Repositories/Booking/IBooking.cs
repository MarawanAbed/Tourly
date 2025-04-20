using BookingEntities=TravelBookingPortal.Domain.Entites.Booking.BookingEntities;

namespace TravelBookingPortal.Application.Interfaces.Repositories.Booking
{
    public interface IBookingRepository
    {
        public Task<BookingEntities> GetBookingByIdAsync(int bookingId);
        public Task UpdateAsync(BookingEntities booking);

        public Task<BookingEntities> GetLastBookingPendingForUserAsync(string userId);
        public Task<IEnumerable<BookingEntities>> GetBookingByUserIdAsync(string userId);
        public Task DeleteBookingForUserAsync(int bookingId);
    }
}
