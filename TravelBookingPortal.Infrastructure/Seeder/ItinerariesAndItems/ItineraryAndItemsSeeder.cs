using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Domain.Enitites.ItineraryEntities;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Seeder.ItinerariesAndItems
{
    public class ItineraryAndItemsSeeder : IItineraryAndItemsSeeder
    {
        private readonly TravelBookingPortalDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public ItineraryAndItemsSeeder(TravelBookingPortalDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task SeedItinerariesAndItems()
        {
            if (!dbContext.Itineraries.Any())
            {
                var john = await userManager.FindByEmailAsync("john.doe@example.com");

                var itineraries = new List<Itinerary>
                {
                    new Itinerary
                    {
                        UserId = john.Id,
                        Title = "New York Trip",
                        StartDate = DateTime.UtcNow.AddDays(1),
                        EndDate = DateTime.UtcNow.AddDays(3),
                        Notes = "Explore the city",
                        Items = new List<ItineraryItem>
                        {
                            new ItineraryItem { Description = "Visit Statue of Liberty", DateTime = DateTime.UtcNow.AddDays(1).AddHours(10) },
                            new ItineraryItem { Description = "Dinner at Times Square", DateTime = DateTime.UtcNow.AddDays(1).AddHours(18) }
                        }
                    }
                };

                await dbContext.Itineraries.AddRangeAsync(itineraries);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
