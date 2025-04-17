

using MediatR;
using Microsoft.AspNetCore.Http;
using TravelBookingPortal.Domain.Enitites.CityEnities;
using TravelBookingPortal.Domain.Enitites.ReviewEntities;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Application.Admin.Hotels.Commands.Create
{
    public class CreateHotelCommand : IRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public int CityId { get; set; }
    }
}
