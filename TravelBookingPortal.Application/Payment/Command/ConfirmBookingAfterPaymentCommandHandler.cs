using MediatR;
using IBookingStatusNotifier = TravelBookingPortal.Application.Interfaces.Hubs.IBookingStatusNotifier;
using TravelBookingPortal.Application.Interfaces.Repositories.Booking;

namespace TravelBookingPortal.Application.Payment.Command
{
    public class ConfirmBookingAfterPaymentCommandHandler(
        IBookingRepository bookingRepository,
         IBookingStatusNotifier notifier
            ) : IRequestHandler<ConfirmBookingAfterPaymentCommand, Unit>
    {
        public async Task<Unit> Handle(ConfirmBookingAfterPaymentCommand request, CancellationToken cancellationToken)
        {

            var booking = await bookingRepository.GetBookingByIdAsync(request.BookingId);




            //await bookingRepository.UpdateAsync(booking);
            booking.BookingStatus = "Confirmed";

            await bookingRepository.UpdateAsync(booking);

            


            await notifier.NotifyBookingStatusAsync(booking.RoomId, "Confirmed");

            return Unit.Value;
        }


    }
}