
using MediatR;


using TravelBookingPortal.Application.RoomLogic.Commands.Models;

using TravelBookingPortal.Domain.IHubs;
using TravelBookingPortal.Domain.Repositories.RoomRepo;

namespace TravelBookingPortal.Application.RoomLogic.Commands.Handler
{
    public class BookRoomCommandHandler : IRequestHandler<BookRoomCommand>
    {
        private readonly IBookingStatusNotifier notifier;
        private readonly IRoomRepository roomRepository;

        public BookRoomCommandHandler(IBookingStatusNotifier notifier, IRoomRepository roomRepository)
        {
            this.notifier = notifier;
            this.roomRepository = roomRepository;
        }
        public async Task Handle(BookRoomCommand request, CancellationToken cancellationToken)
        {
            await roomRepository.AddBookingAsync(request.UserId, request.RoomId, request.CheckIn, request.CheckOut,request.TotalPrice);


            await notifier.NotifyBookingStatusAsync(request.RoomId, "Pending");


        }
    }
}
