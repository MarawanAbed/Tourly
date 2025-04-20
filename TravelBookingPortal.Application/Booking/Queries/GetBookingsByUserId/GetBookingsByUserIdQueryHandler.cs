
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Booking.Dtos;
using TravelBookingPortal.Application.Interfaces.Repositories.Booking;

namespace TravelBookingPortal.Application.Booking.Queries.GetBookingsByUserId
{
    public class GetBookingsByUserIdQueryHandler(IBookingRepository bookingRepository, IMapper mapper) : IRequestHandler<GetBookingsByUserIdQuery, List<GetBookingsByUserIdDto>>
    {
        async Task<List<GetBookingsByUserIdDto>> IRequestHandler<GetBookingsByUserIdQuery, List<GetBookingsByUserIdDto>>.Handle(GetBookingsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var bookingList = await bookingRepository.GetBookingByUserIdAsync(request.UserId);
            var bookingMapper = mapper.Map<List<GetBookingsByUserIdDto>>(bookingList);
            return bookingMapper;
        }
    }

}
