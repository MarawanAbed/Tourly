using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Application.BookingLogic.DTOs;
using TravelBookingPortal.Domain.Enitites.BookingEntities;

namespace TravelBookingPortal.Application.BookingLogic.Mapper
{
    public partial class BookingProfile
    {
        public void GetBookingsByUserIdMapper()
        {
            CreateMap<Booking, GetBookingsByUserIdDTO>()
                .ForMember(dest => dest.RoomNumber, op => op.MapFrom(src => src.Room.RoomNumber))
                .ForMember(dest => dest.PricePerNight, op => op.MapFrom(src => src.Room.PricePerNight))
                .ForMember(dest => dest.RoomType, op => op.MapFrom(src => src.Room.RoomType))
                .ForMember(dest => dest.HotelName, op => op.MapFrom(src => src.Room.Hotel.Name))
                .ForMember(dest => dest.CityName, op => op.MapFrom(src => src.Room.Hotel.City.Name))
                .ForMember(dest=>dest.TotalPrice,op => op.MapFrom(src => src.TotalPrice));    




        }
    }
}
