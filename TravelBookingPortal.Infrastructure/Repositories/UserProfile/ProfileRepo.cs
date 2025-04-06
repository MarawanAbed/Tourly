using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Enitites.PreferenceEnitites;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.Profile;
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
         string ImageUrl,
         string PhoneNumber ,
         string? State,
         string? City ,
         string? Street ,
        List<Preference> prefrences)
        {
           var user = await _context.Users.Include(p => p.Preferences).FirstOrDefaultAsync(u => u.Id == UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.ImageUrl = ImageUrl;
            user.PhoneNumber = PhoneNumber;
            user.State = State;
            user.City = City;
            user.Street = Street;

            var oldprefrences =await _context.UserPreferences.Where(p => p.UserId == UserId).ToListAsync();

             _context.UserPreferences.RemoveRange(oldprefrences);
            if(prefrences != null && prefrences.Count > 0)
            {
                foreach (var preference in prefrences)
                {
                    preference.UserId = UserId;
                    
                }
              await _context.UserPreferences.AddRangeAsync(prefrences);
            }
            await _context.SaveChangesAsync();

            
        }
    }
}
