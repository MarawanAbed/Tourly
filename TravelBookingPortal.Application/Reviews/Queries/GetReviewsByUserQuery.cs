using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Application.Reviews.DTOs;


namespace TravelBookingPortal.Application.Reviews.Queries
{
  
        public class GetReviewsByUserQuery : IRequest<List<ReviewDto>>
        {
            public string UserId { get; set; } = null!;
        }
    }

