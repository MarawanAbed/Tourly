
using MediatR;
using TravelBookingPortal.Application.Admin.Booking.Dtos;

namespace TravelBookingPortal.Application.Admin.Booking.Queries
{
    public class GetAllBookingsQueries : IRequest<List<GetAllBookingsDto>>
    {
    }


}
