using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.Booking.Dtos;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Booking;

namespace TravelBookingPortal.Application.Admin.Booking.Queries
{

    public class GetAllBookingsQueriesHandler(IMapper mapper, IBookingRepository bookings) : IRequestHandler<GetAllBookingsQueries, List<GetAllBookingsDto>>
    {
        public async Task<List<GetAllBookingsDto>> Handle(GetAllBookingsQueries request, CancellationToken cancellationToken)
        {
            var bookingsList = await bookings.GetAllBookings();
            return mapper.Map<List<GetAllBookingsDto>>(bookingsList);
        }
    }
}
