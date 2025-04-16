using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.BookingLogic.DTOs;
using TravelBookingPortal.Application.BookingLogic.Queries.Models;
using TravelBookingPortal.Domain.Repositories.BookingRepo;

namespace TravelBookingPortal.Application.BookingLogic.Queries.Handlers
{
    public class   GetBookingsByUserIdQueryHandler : IRequestHandler<GetBookingsByUserIdQuery, List<GetBookingsByUserIdDTO>>
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public GetBookingsByUserIdQueryHandler(IBookingRepository bookingRepository,IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }
        async Task<List<GetBookingsByUserIdDTO>> IRequestHandler<GetBookingsByUserIdQuery, List<GetBookingsByUserIdDTO>>.Handle(GetBookingsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var bookingList=await bookingRepository.GetBookingByUserIdAsync(request.UserId);
            var bookingMapper= mapper.Map<List<GetBookingsByUserIdDTO>>(bookingList);
            return bookingMapper;
        }
    }

}
