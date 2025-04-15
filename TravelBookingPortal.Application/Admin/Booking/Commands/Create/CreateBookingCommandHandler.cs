

using AutoMapper;
using MediatR;
using TravelBookingPortal.Domain.Repositories.Admin.Booking;

namespace TravelBookingPortal.Application.Admin.Booking.Commands.Create
{
    public class CreateBookingCommandHandler(IMapper mapper,IBooking bookings) : IRequestHandler<CreateBookingCommand>
    {
        public async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = mapper.Map<Domain.Enitites.BookingEntities.Booking>(request);
            await bookings.AddBooking(booking);
        }
    }

}
