using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Application.Reviews.DTOs;

namespace TravelBookingPortal.Application.RoomLogic.Queries.Handlers
{
    public class GetReviewsByHotelQuery : IRequest<List<ReviewDto>>
    {
        public string HotelName { get; set; }
    }
   
}
