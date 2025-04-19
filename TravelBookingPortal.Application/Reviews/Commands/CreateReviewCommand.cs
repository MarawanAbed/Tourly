using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Application.Reviews.DTOs;

namespace TravelBookingPortal.Application.Reviews.Commands
{
    public class CreateReviewCommand :IRequest
    {
        public string UserId { get; set; } = null!;
        public string HotelName { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        
    }
}
