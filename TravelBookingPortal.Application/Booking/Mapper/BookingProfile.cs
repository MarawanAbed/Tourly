
using AutoMapper;
using BookingEntities = TravelBookingPortal.Domain.Entites.Booking.BookingEntities;
using TravelBookingPortal.Application.Booking.Dtos;

namespace TravelBookingPortal.Application.Booking.Mapper
{
    public partial class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingEntities, GetBookingsByUserIdDto>()
                .ForMember(dest => dest.RoomNumber, op => op.MapFrom(src => src.Room.RoomNumber))
                .ForMember(dest => dest.PricePerNight, op => op.MapFrom(src => src.Room.PricePerNight))
                .ForMember(dest => dest.RoomType, op => op.MapFrom(src => src.Room.RoomType))
                .ForMember(dest => dest.HotelName, op => op.MapFrom(src => src.Room.Hotel.Name))
                .ForMember(dest => dest.CityName, op => op.MapFrom(src => src.Room.Hotel.City.Name))
                .ForMember(dest => dest.TotalPrice, op => op.MapFrom(src => src.TotalPrice));

            CreateMap<BookingEntities, GetLastBookingByUserIdDTO>();
        }
    }
}
