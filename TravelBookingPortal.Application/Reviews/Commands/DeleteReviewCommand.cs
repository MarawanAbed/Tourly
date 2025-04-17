using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TravelBookingPortal.Application.Reviews.Commands
{
    public class DeleteReviewCommand : IRequest
    {
        public int ReviewId { get; set; }
    }
}