

using MediatR;
using Microsoft.AspNetCore.Http;

namespace TravelBookingPortal.Application.Admin.Hotel.Commands.Update
{
    public class UpdateHotelCommand : IRequest
    {
        public int HotelId { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public IFormFile? ImageUrl { get; set; }
    }

}
