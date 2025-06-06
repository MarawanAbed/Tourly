﻿

namespace TravelBookingPortal.Application.UserProfile.Dtos
{
    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Street { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }      
    }
}
