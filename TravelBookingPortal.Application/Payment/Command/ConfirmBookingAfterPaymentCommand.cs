
using MediatR;

namespace TravelBookingPortal.Application.Payment.Command
{
    public class ConfirmBookingAfterPaymentCommand : IRequest<Unit>
    {


        public int BookingId { get; }
        public ConfirmBookingAfterPaymentCommand(int bookingId)
        {
            BookingId = bookingId;
        }


    }
}
