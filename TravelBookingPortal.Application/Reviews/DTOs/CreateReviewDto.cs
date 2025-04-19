﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingPortal.Application.Reviews.DTOs
{
    public class CreateReviewDto
    {
        public string UserId { get; set; } = null!;
        public int HotelId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

    }
}
