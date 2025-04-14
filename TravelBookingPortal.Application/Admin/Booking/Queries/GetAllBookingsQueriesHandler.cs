using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.Booking.Dtos;
using TravelBookingPortal.Domain.Repositories.Admin.Booking;

namespace TravelBookingPortal.Application.Admin.Booking.Queries
{
    public class GetAllBookingsQuery : IRequest<List<GetAllBookingsDto>>
    {
        public int HotelId { get; set; }
    }

    public class GetAllBookingsQueriesHandler : IRequestHandler<GetAllBookingsQuery, List<GetAllBookingsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBooking _bookings;

        public GetAllBookingsQueriesHandler(IMapper mapper, IBooking bookings)
        {
            _mapper = mapper;
            _bookings = bookings;
        }

        public async Task<List<GetAllBookingsDto>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var bookingsList = await _bookings.GetAllBookings();
            return _mapper.Map<List<GetAllBookingsDto>>(bookingsList);
        }
    }
}
