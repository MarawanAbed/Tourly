using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.BookingLogic.DTOs;
using TravelBookingPortal.Application.BookingLogic.Queries.Models;
using TravelBookingPortal.Domain.Repositories.BookingRepo;

namespace TravelBookingPortal.Application.BookingLogic.Queries.Handlers
{
   public  class GetLastBookingQueryHandler : IRequestHandler<GetlastBookingQuery, GetLastBookingByUserIdDTO>
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public GetLastBookingQueryHandler(IBookingRepository bookingRepository,IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }
        public async Task<GetLastBookingByUserIdDTO> Handle(GetlastBookingQuery request, CancellationToken cancellationToken)
        {
            var booking = await bookingRepository.GetLastBookingPendingForUserAsync(request.UserId);
            var mappedBooking = mapper.Map<GetLastBookingByUserIdDTO>(booking);
            return mappedBooking;
        }
    }
}
