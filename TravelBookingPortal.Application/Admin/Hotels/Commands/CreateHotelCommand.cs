

using MediatR;
using TravelBookingPortal.Domain.Enitites.CityEnities;
using TravelBookingPortal.Domain.Enitites.ReviewEntities;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Application.Admin.Hotels.Commands
{
    public class CreateHotelCommand : IRequest
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public List<Room>? Rooms { get; set; }
        public List<TravelBookingPortal.Domain.Enitites.BookingEntities.Booking>? Bookings { get; set; }
        public List<Review>? Reviews { get; set; }


        public City? City { get; set; }

        public int CityId { get; set; }
    }
}
