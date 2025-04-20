

using Microsoft.AspNetCore.Identity;
using TravelBookingPortal.Application.Interfaces.Seeder.Reviews;
using TravelBookingPortal.Domain.Entites.Review;
using TravelBookingPortal.Domain.Entites.User;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Seeder.Reviews
{
    public class ReviewSeeder(TravelBookingPortalDbContext dbContext, UserManager<ApplicationUser> userManager) : IReviewSeeder
    {
        public async Task SeedReviews()
        {
            if (!dbContext.Reviews.Any())
            {
                var john = await userManager.FindByEmailAsync("john.doe@example.com");
                var jane = await userManager.FindByEmailAsync("jane.smith@example.com");

                var reviews = new List<ReviewEntities>
                {
                    new() {
                        UserId = john.Id,
                        HotelId = 2,
                        Rating = 4,
                        Comment = "Great stay, friendly staff!",
                        CreatedAt = DateTime.UtcNow.AddDays(-1)
                    },
                    new() {
                        UserId = jane.Id,
                        HotelId = 3,
                        Rating = 5,
                        Comment = "Amazing beach view!",
                        CreatedAt = DateTime.UtcNow.AddDays(-2)
                    }
                };

                await dbContext.Reviews.AddRangeAsync(reviews);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
