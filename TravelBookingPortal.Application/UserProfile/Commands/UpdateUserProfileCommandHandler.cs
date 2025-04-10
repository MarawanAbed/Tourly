using AutoMapper;
using MediatR;

using TravelBookingPortal.Domain.Repositories.UserProfile;

namespace TravelBookingPortal.Application.UserProfile.Commands
{
    public class UpdateUserProfileCommandHandler: IRequestHandler<UpdateUserProfileCommand, bool>
    { private readonly IProfileRepo _profileRepo;
        private readonly IMapper mapper;


        public UpdateUserProfileCommandHandler(IProfileRepo profileRepo, IMapper mapper)
        {
            _profileRepo = profileRepo;
            this.mapper = mapper;
        }
        public  async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _profileRepo.GetUserProfileAsync(request.UserId);
            if (user == null)
            {
                Console.WriteLine("User not found");
                return false;
            }
            var files = request.Image;
            string imageUrl = null;
            if (files != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(files.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await files.CopyToAsync(stream);
                }
                imageUrl = $"/images/{fileName}";
            }
            
            await _profileRepo.UpdateUserProfileAsync(request.UserId, request.FirstName,request.LastName,imageUrl, request.PhoneNumber,request.State,request.City,request.Street,request.Email,request.UserName);

            return true;

        }
    }
    
}
