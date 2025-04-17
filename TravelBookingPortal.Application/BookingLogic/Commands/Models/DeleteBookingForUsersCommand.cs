using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TravelBookingPortal.Application.BookingLogic.Commands.Models
{
   public class DeleteBookingForUsersCommand :IRequest
    {
        public int BookingId { get; set; }
    }
}
