
using AutoMapper;
using TravelBookingPortal.Application.Admin.Booking.Commands.Create;
using TravelBookingPortal.Application.Admin.Booking.Dtos;

namespace TravelBookingPortal.Application.Admin.Booking.Mapper
{
    public class BookingProfile : Profile
    {

        public BookingProfile() {
            CreateMap<Domain.Enitites.BookingEntities.Booking, CreateBookingCommand>();

            CreateMap<Domain.Enitites.BookingEntities.Booking, GetAllBookingsDto>()
                .ForMember(GetAllBookingsDto => GetAllBookingsDto.HotelName, opt => opt.MapFrom(src => src.Room.Hotel.Name))
                .ForMember(GetAllBookingsDto => GetAllBookingsDto.UserName, GetAllBookingsDto => GetAllBookingsDto.MapFrom(src => src.User.UserName));

        }
    }
}
