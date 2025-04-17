using MediatR;

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
