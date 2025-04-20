
using AutoMapper;
using TravelBookingPortal.Application.Admin.Booking.Commands.Create;
using TravelBookingPortal.Application.Admin.Booking.Dtos;
using TravelBookingPortal.Domain.Entites.Booking;

namespace TravelBookingPortal.Application.Admin.Booking.Mapper
{
    public class BookingProfile : Profile
    {

        public BookingProfile() {
            CreateMap<BookingEntities, CreateBookingCommand>();

            CreateMap<CreateBookingCommand, BookingEntities>();

            CreateMap<BookingEntities, GetAllBookingsDto>()
                .ForMember(GetAllBookingsDto => GetAllBookingsDto.HotelName, opt => opt.MapFrom(src => src.Room.Hotel.Name))
                .ForMember(GetAllBookingsDto => GetAllBookingsDto.UserName, GetAllBookingsDto => GetAllBookingsDto.MapFrom(src => src.User.UserName));

        }
    }
}
