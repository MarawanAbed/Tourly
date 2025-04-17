﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TravelBookingPortal.Application.Reviews.Commands
{
    public class UpdateReviewCommand : IRequest
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}