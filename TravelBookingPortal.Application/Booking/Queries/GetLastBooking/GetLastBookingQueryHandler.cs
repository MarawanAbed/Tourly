
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Booking.Dtos;
using TravelBookingPortal.Application.Interfaces.Repositories.Booking;

namespace TravelBookingPortal.Application.Booking.Queries.GetLastBooking
{
    public class GetLastBookingQueryHandler(IBookingRepository bookingRepository, IMapper mapper) : IRequestHandler<GetlastBookingQuery, GetLastBookingByUserIdDTO>
    {
        public async Task<GetLastBookingByUserIdDTO> Handle(GetlastBookingQuery request, CancellationToken cancellationToken)
        {
            var booking = await bookingRepository.GetLastBookingPendingForUserAsync(request.UserId);
            var mappedBooking = mapper.Map<GetLastBookingByUserIdDTO>(booking);
            return mappedBooking;
        }
    }
}
