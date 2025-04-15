

using MediatR;
using TravelBookingPortal.Application.Admin.Hotels.Dtos;

namespace TravelBookingPortal.Application.Admin.Hotels.Queries
{
    public class GetAllHotelsQueries : IRequest<List<GetAllHotelsDto>>
    {
    }
}
