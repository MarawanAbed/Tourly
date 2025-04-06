using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Application.UserProfile.Dtos;

namespace TravelBookingPortal.Application.UserProfile.Commands
{
    public class UpdateUserProfileCommand:IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }

        public List<PreferenceDto> Preferences { get; set; }
    }
   
}
