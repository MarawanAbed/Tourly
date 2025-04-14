

using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Domain.Enitites.PreferenceEnitites;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Seeder.Preferences
{
    public class PreferenceSeeder(TravelBookingPortalDbContext dbContext, UserManager<ApplicationUser> userManager) : IPreferenceSeeder
    {

        public async Task SeedPreferences()
        {
            if (!dbContext.UserPreferences.Any())
            {
                var john = await userManager.FindByEmailAsync("john.doe@example.com");
                var jane = await userManager.FindByEmailAsync("jane.smith@example.com");

                var preferences = new List<Preference>
                {
                    new() {  UserId = john.Id, PreferenceType = "RoomType", PreferenceValue = "Non-Smoking" },
                    new() {  UserId = jane.Id, PreferenceType = "Amenities", PreferenceValue = "Wi-Fi" }
                };

                await dbContext.UserPreferences.AddRangeAsync(preferences);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
