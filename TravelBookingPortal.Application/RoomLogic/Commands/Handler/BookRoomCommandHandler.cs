using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;

using TravelBookingPortal.Application.RoomLogic.Commands.Models;

using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.IHubs;
using TravelBookingPortal.Domain.Repositories.RoomRepo;

namespace TravelBookingPortal.Application.RoomLogic.Commands.Handler
{
    public class BookRoomCommandHandler : IRequestHandler<BookRoomCommand>
    {
        private readonly IBookingHub _bookingHub;
        private readonly IRoomRepository roomRepository;

        public BookRoomCommandHandler(IBookingHub bookingHub,IRoomRepository roomRepository)
        {
            _bookingHub = bookingHub;
            this.roomRepository = roomRepository;
        }
        public async Task Handle(BookRoomCommand request, CancellationToken cancellationToken)
        {
            await roomRepository.AddBookingAsync(request.UserId, request.RoomId, request.CheckIn, request.CheckOut,request.TotalPrice);


            await _bookingHub.SendBookingUpdate("Pending");


        }
    }
}
