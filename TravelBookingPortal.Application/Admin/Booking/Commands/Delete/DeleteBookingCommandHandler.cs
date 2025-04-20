

using MediatR;
using TravelBookingPortal.Application.Interfaces.Hubs;
using TravelBookingPortal.Application.Interfaces.Repositories.Booking;
using IAdminBooking=TravelBookingPortal.Application.Interfaces.Repositories.Admin.Booking.IBookingRepository;


namespace TravelBookingPortal.Application.Admin.Booking.Commands.Delete
{
    public class DeleteBookingCommandHandler(IAdminBooking adminBooking, IBookingStatusNotifier notifier,IBookingRepository bookingRepo) : IRequestHandler<DeleteBookingCommand>
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
            await adminBooking.DeleteBooking(request.BookingId);
           
            await notifier.NotifyBookingStatusAsync(roomId, "Available");




        }
    }
}
