

using AutoMapper;
using TravelBookingPortal.Application.Admin.Rooms.Commands;
using TravelBookingPortal.Application.Admin.Rooms.Dtos;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Application.Admin.Rooms.Mapper
{
    public class RoomsProfile : Profile
    {
        public RoomsProfile() 
        {
            CreateMap<Room, CreateRoomCommand>();

            CreateMap<Room, GetAllRoomsDto>()
                .ForMember(des => des.HotelName, opt => opt.MapFrom(src => src.Hotel.Name));
        }
    }
}
