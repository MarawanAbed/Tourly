using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Application.Interfaces.Seeder.ItinerariesAndItems;
using TravelBookingPortal.Domain.Entites.Itinerary;
using TravelBookingPortal.Domain.Entites.User;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Seeder.ItinerariesAndItems
{
    public class ItineraryAndItemsSeeder(TravelBookingPortalDbContext dbContext, UserManager<ApplicationUser> userManager) : IItineraryAndItemsSeeder
    {
        private readonly TravelBookingPortalDbContext dbContext = dbContext;
        private readonly UserManager<ApplicationUser> userManager = userManager;

        public async Task SeedItinerariesAndItems()
        {
            if (!dbContext.Itineraries.Any())
            {
                var john = await userManager.FindByEmailAsync("john.doe@example.com");

                var itineraries = new List<ItineraryEntities>
                {
                    new ItineraryEntities
                    {
                        UserId = john.Id,
                        Title = "New York Trip",
                        StartDate = DateTime.UtcNow.AddDays(1),
                        EndDate = DateTime.UtcNow.AddDays(3),
                        Notes = "Explore the city",

                    }
                };

                await dbContext.Itineraries.AddRangeAsync(itineraries);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
