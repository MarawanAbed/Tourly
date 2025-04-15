using MediatR;
using Microsoft.AspNetCore.Http;

namespace TravelBookingPortal.Application.Admin.Rooms.Commands.Create
{
    public class CreateRoomCommand : IRequest
    {
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
