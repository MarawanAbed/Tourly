using MediatR;
using Microsoft.AspNetCore.Http;
using TravelBookingPortal.Application.UserProfile.Dtos;

namespace TravelBookingPortal.Application.UserProfile.Commands
{
    public class UpdateUserProfileCommand:IRequest<bool>
    {
        public string UserId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile? Image { get; set; }
        public string PhoneNumber { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public List<PreferenceDto> Preferences { get; set; }
    }
   
}
