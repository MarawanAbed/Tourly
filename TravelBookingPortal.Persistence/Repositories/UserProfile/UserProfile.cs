using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Application.Interfaces.Repositories.UserProfile;
using TravelBookingPortal.Domain.Entites.User;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Repositories.UserProfile
{
    public class UserProfileRepository(TravelBookingPortalDbContext context) : IUserProfileRepository
    {
        public async Task<ApplicationUser> GetUserProfileAsync(string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId) ?? throw new Exception("User not found");
            return user;
        }

        public async Task UpdateUserProfileAsync(string UserId, string FirstName,
         string LastName,
         string? ImageUrl,
         string PhoneNumber,
         string? State,
         string? City,
         string? Street,
         string Email,
         string UserName
        )
        {
            var user = await context.Users.FirstOrDefaultAsync(p => p.Id == UserId) ?? throw new Exception("User not found");
            user.FirstName = FirstName;
            user.LastName = LastName;
            if (ImageUrl != null)
            {
                user.ImageUrl = ImageUrl;
            }
            user.ImageUrl = user.ImageUrl;
            user.PhoneNumber = PhoneNumber;
            user.State = State;
            user.City = City;
            user.Street = Street;
            user.Email = Email;
            user.UserName = UserName;
            user.CreatedAt = user.CreatedAt;
            user.DateOfBirth = user.DateOfBirth;


            await context.SaveChangesAsync();


        }
    }
}