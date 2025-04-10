using Microsoft.EntityFrameworkCore;

using TravelBookingPortal.Domain.Enitites.PreferenceEnitites;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.UserProfile;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Repositories.Profile
{
    public class ProfileRepo:IProfileRepo
    {
        private readonly TravelBookingPortalDbContext _context;
        public ProfileRepo(TravelBookingPortalDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUserProfileAsync(string userId)
        {
           var user=await _context.Users.Include(p=>p.Preferences).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task UpdateUserProfileAsync(string UserId   ,string FirstName,
         string LastName ,
         string? ImageUrl,
         string PhoneNumber ,
         string? State,
         string? City ,
         string? Street ,
         string Email,
         string UserName
        )
        {
            var user = await _context.Users.FirstOrDefaultAsync(p=>p.Id==UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.FirstName = FirstName;
            user.LastName = LastName;
            if (ImageUrl != null)
            {
                user.ImageUrl = ImageUrl;
            }
            user.ImageUrl=user.ImageUrl;
            user.PhoneNumber = PhoneNumber;
            user.State = State;
            user.City = City;
            user.Street = Street;
            user.Email = Email;
            user.UserName = UserName;
            user.CreatedAt=user.CreatedAt;
            user.DateOfBirth = user.DateOfBirth;
           
            
            await _context.SaveChangesAsync();


        }
    }
}
