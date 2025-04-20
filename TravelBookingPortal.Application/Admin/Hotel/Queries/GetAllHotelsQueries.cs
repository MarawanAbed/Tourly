

using MediatR;
using TravelBookingPortal.Application.Admin.Hotel.Dtos;

namespace TravelBookingPortal.Application.Admin.Hotel.Queries
{
    public class GetAllHotelsQueries : IRequest<List<GetAllHotelsDto>>
    {
    }
}
