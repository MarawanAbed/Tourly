using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Application.UserProfile.Dtos;

namespace TravelBookingPortal.Application.UserProfile.Queries
{
    public class GetUserProfileQuery:IRequest<UserProfileDto>
    {
        public string UserId { get; set; }
        public GetUserProfileQuery(string userId)
        {
            UserId = userId;
        }

    }
   
}
