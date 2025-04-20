using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Application.Interfaces.Repositories.UserProfile;

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

            string imageUrl=await ImageUpload.UploadImage(request.Image);
             


            await profileRepo.UpdateUserProfileAsync(request.UserId, request.FirstName,request.LastName,imageUrl, request.PhoneNumber,request.State,request.City,request.Street,request.Email,request.UserName);

            return true;

        }
    }
    
}
