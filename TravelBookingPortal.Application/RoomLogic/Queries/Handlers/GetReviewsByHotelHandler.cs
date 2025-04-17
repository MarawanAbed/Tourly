using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Reviews.DTOs;
using TravelBookingPortal.Domain.Repositories.ReviewRepo;

namespace TravelBookingPortal.Application.RoomLogic.Queries.Handlers
{
    public class GetReviewsByHotelHandler : IRequestHandler<GetReviewsByHotelQuery, List<ReviewDto>>
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;

        public GetReviewsByHotelHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ReviewDto>> Handle(GetReviewsByHotelQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetByHotelIdAsync(request.HotelId);
            return _mapper.Map<List<ReviewDto>>(reviews);
        }
    }
}