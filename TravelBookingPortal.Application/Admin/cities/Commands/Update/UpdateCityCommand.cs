using MediatR;
using Microsoft.AspNetCore.Http;


namespace TravelBookingPortal.Application.Admin.cities.Commands.Update
{
    public class UpdateCityCommand : IRequest
    {
        public int CityId { get; set; }
        public string? Name { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
