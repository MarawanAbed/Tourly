
using MediatR;
using TravelBookingPortal.Application.Interfaces.Hubs;
using TravelBookingPortal.Application.Interfaces.Repositories.Room;

namespace TravelBookingPortal.Application.Room.Commands
{
    public class BookRoomCommandHandler(IBookingStatusNotifier notifier, IRoomRepository roomRepository) : IRequestHandler<BookRoomCommand>
    {
        public async Task Handle(BookRoomCommand request, CancellationToken cancellationToken)
        {
            await roomRepository.AddBookingAsync(request.UserId, request.RoomId, request.CheckIn, request.CheckOut, request.TotalPrice);


            await notifier.NotifyBookingStatusAsync(request.RoomId, "Pending");


        }
    }
}
