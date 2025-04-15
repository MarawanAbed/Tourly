

using MediatR;

namespace TravelBookingPortal.Application.Admin.cities.Commands.Delete
{
    public class DeleteCityCommand : IRequest
    {

        public int CityId { get; set; }
    }
}
