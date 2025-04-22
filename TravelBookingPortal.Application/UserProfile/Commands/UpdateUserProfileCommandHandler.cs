using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Application.Interfaces.Repositories.UserProfile;
using TravelBookingPortal.Application.UserProfile.Response;

namespace TravelBookingPortal.Application.UserProfile.Commands
{
    public class UpdateUserProfileCommandHandle(IUserProfileRepository profileRepo, IMapper mapper) : IRequestHandler<UpdateUserProfileCommand, bool>
    {
        public async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await profileRepo.GetUserProfileAsync(request.UserId);
            if (user == null)
            {
                Console.WriteLine("User not found");
                return false;
            }
            string imageUrl = await ImageUpload.UploadImage(request.Image);

            var result = await profileRepo.UpdateUserProfileAsync(request.UserId, request.FirstName, request.LastName, imageUrl, request.PhoneNumber, request.State, request.City, request.Street, request.Email, request.UserName);

            if (result)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Failed to update user profile");
                return false;
            }
        }
    }

}
