using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.BookingLogic.Commands.Models;
using TravelBookingPortal.Domain.Repositories.BookingRepo;

namespace TravelBookingPortal.Application.BookingLogic.Commands.Handlers
{
    class DeletebookingForUserCommandHandler :IRequestHandler<DeleteBookingForUsersCommand>
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public DeletebookingForUserCommandHandler(IBookingRepository bookingRepository)
        {
            
            this.bookingRepository = bookingRepository;
            
        }


        async Task IRequestHandler<DeleteBookingForUsersCommand>.Handle(DeleteBookingForUsersCommand request, CancellationToken cancellationToken)
        {
            await bookingRepository.DeleteBookingForUserAsync(request.BookingId);

        }
    }
    
}
