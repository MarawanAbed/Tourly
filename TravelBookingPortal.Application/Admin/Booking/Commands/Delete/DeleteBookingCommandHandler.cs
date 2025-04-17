

using MediatR;
using TravelBookingPortal.Domain.IHubs;
using TravelBookingPortal.Domain.Repositories.Admin.Booking;
using TravelBookingPortal.Domain.Repositories.BookingRepo;
using TravelBookingPortal.Domain.Repositories.RoomRepo;

namespace TravelBookingPortal.Application.Admin.Booking.Commands.Delete
{
    public class DeleteBookingCommandHandler(IBooking bookings, IBookingStatusNotifier notifier,IBookingRepository bookingRepo) : IRequestHandler<DeleteBookingCommand>
    {
        public async Task Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {

            var bookingId = request.BookingId;
            var booking = await bookingRepo.GetBookingByIdAsync(request.BookingId);
            
            if (bookingId == 0)
            {
                throw new ArgumentException("Booking ID cannot be zero.");
            }
            int roomId = booking.RoomId;
            await bookings.DeleteBooking(request.BookingId);
           
            await notifier.NotifyBookingStatusAsync(roomId, "Available");




        }
    }
}
