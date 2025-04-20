

using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Booking;
using TravelBookingPortal.Domain.Entites.Booking;

namespace TravelBookingPortal.Application.Admin.Booking.Commands.Create
{
    public class CreateBookingCommandHandler(IMapper mapper,IBookingRepository bookings) : IRequestHandler<CreateBookingCommand>
    {
        public async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = mapper.Map<BookingEntities>(request);
            await bookings.AddBooking(booking);
        }
    }

}
