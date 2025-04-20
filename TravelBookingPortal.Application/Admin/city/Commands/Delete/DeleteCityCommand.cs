

using MediatR;

namespace TravelBookingPortal.Application.Admin.city.Commands.Delete
{
    public class DeleteCityCommand : IRequest
    {

        public int CityId { get; set; }
    }
}
