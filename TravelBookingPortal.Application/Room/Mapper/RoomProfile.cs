
using AutoMapper;
using TravelBookingPortal.Application.Room.Dtos;
using TravelBookingPortal.Domain.Entites.Booking;
using TravelBookingPortal.Domain.Entites.Room;

namespace TravelBookingPortal.Application.Room.Mapper
{
    public partial class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<BookingEntities, BookingRoomDto>();
            CreateMap<RoomEntities, GetOneRoomDTO>().ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Hotel.City.Name))
                ;
            CreateMap<RoomEntities, GetRoomsDTO>()
            .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name));
        }
    }
}
