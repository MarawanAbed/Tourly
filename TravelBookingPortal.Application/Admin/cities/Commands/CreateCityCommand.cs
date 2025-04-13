

using MediatR;
using TravelBookingPortal.Domain.Enitites.HotelEntities;

namespace TravelBookingPortal.Application.Admin.cities.Commands
{
    public class CreateCityCommand : IRequest
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }


        public List<Hotel>? Hotels { get; set; } = new List<Hotel>();
    }
}
