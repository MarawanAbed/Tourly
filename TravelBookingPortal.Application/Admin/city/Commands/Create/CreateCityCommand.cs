

using MediatR;
using Microsoft.AspNetCore.Http;

namespace TravelBookingPortal.Application.Admin.city.Commands.Create
{
    public class CreateCityCommand : IRequest
    {
        public string Name { get; set; }

        public IFormFile ImageUrl { get; set; }
    }
}
