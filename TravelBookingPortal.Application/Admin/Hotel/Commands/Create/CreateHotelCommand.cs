

using MediatR;
using Microsoft.AspNetCore.Http;


namespace TravelBookingPortal.Application.Admin.Hotel.Commands.Create
{
    public class CreateHotelCommand : IRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public int CityId { get; set; }
    }
}
