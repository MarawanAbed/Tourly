﻿namespace TravelBookingPortal.Application.ItineraryFeatures.Dtos
{
    public class ItineraryDto
    {
        public int ItineraryId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }
    }
}
