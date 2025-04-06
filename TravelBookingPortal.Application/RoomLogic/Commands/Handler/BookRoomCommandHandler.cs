using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;

using TravelBookingPortal.Application.RoomLogic.Commands.Models;
using TravelBookingPortal.Application.RoomLogic.Commands.RoomService.Abstraction;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.IHubs;

namespace TravelBookingPortal.Application.RoomLogic.Commands.Handler
{
    public class BookRoomCommandHandler : IRequestHandler<BookRoomCommand>
    {
        private readonly IBookingHub _bookingHub;
        private readonly IRoomServiceCommands roomService;

        public BookRoomCommandHandler(IBookingHub bookingHub,IRoomServiceCommands roomService)
        {
            _bookingHub = bookingHub;
            this.roomService = roomService;
        }
        public async Task Handle(BookRoomCommand request, CancellationToken cancellationToken)
        {
            await roomService.BookRoomAsync(request.UserId, request.RoomId, request.CheckIn, request.CheckOut,request.TotalPrice);


            //await _bookingHub.SendBookingUpdate("Pending");

            
        }
    }
}
