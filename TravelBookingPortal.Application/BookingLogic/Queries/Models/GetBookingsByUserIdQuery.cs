using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Application.BookingLogic.DTOs;

namespace TravelBookingPortal.Application.BookingLogic.Queries.Models
{
   public class GetBookingsByUserIdQuery :IRequest<List<GetBookingsByUserIdDTO>>
    {
        public string UserId { get; set; }
    }
}
