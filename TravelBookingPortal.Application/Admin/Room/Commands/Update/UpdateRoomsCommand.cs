

using MediatR;
using Microsoft.AspNetCore.Http;

namespace TravelBookingPortal.Application.Admin.Room.Commands.Update
{
    public class UpdateRoomsCommand : IRequest
    {
        public int RoomId { get; set; }
        public string? RoomType { get; set; }
        public decimal? PricePerNight { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
