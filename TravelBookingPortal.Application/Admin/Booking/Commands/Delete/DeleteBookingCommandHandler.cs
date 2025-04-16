

using MediatR;
using TravelBookingPortal.Domain.IHubs;
using TravelBookingPortal.Domain.Repositories.Admin.Booking;
using TravelBookingPortal.Domain.Repositories.RoomRepo;

namespace TravelBookingPortal.Application.Admin.Booking.Commands.Delete
{
    public class DeleteBookingCommandHandler(IBooking bookings) : IRequestHandler<DeleteBookingCommand>
    {
        public async Task Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var bookingId = request.BookingId;
            if (bookingId == 0)
            {
                throw new ArgumentException("Booking ID cannot be zero.");
            }
            await bookings.DeleteBooking(request.BookingId);
         

        }
    }
}
