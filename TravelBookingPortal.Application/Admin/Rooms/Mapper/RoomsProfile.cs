

using AutoMapper;
using TravelBookingPortal.Application.Admin.Rooms.Commands.Create;
using TravelBookingPortal.Application.Admin.Rooms.Commands.Update;
using TravelBookingPortal.Application.Admin.Rooms.Dtos;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Application.Admin.Rooms.Mapper
{
    public class RoomsProfile : Profile
    {
        public RoomsProfile()
        {
            CreateMap<Room, CreateRoomCommand>();


            CreateMap<CreateRoomCommand, Room>()
                .ForMember(des => des.ImageUrl,
                opt => opt.MapFrom<CreateRoomImageResolver>());

            CreateMap<UpdateRoomsCommand, Room>()
                .ForMember(des => des.ImageUrl,
                opt => opt.MapFrom<UpdateRoomImageResolver>());

            CreateMap<Room, GetAllRoomsDto>()
                .ForMember(des => des.HotelName
                , opt => opt.MapFrom(src => src.Hotel.Name));
        }
    }
}
