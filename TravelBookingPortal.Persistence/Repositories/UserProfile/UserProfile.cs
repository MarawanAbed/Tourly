using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Application.Interfaces.Repositories.UserProfile;
using TravelBookingPortal.Domain.Entites.User;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Repositories.UserProfile
{
    public class UserProfileRepository(TravelBookingPortalDbContext context,UserManager<ApplicationUser>userManager) : IUserProfileRepository
    {
        public async Task<ApplicationUser> GetUserProfileAsync(string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId) ?? throw new Exception("User not found");
            return user;
        }

        public async Task<bool> UpdateUserProfileAsync(string UserId, string FirstName,
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

            var isUserNameTaken = await context.Users.AnyAsync(u => u.UserName == user.UserName && u.Id != user.Id);
            if (isUserNameTaken)
            {
                return false; // Username is already taken
            }
            var isEmailTaken = await context.Users.AnyAsync(u => u.Email == user.Email && u.Id != user.Id);
            if (isEmailTaken)
            {
                return false; // Email is already taken
            }
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

            var result = await userManager.UpdateAsync(user);
            return result.Succeeded; // Return true if the update succeeded
        }
    }
}