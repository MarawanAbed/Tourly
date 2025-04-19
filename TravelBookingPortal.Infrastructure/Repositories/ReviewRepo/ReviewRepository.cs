using Microsoft.EntityFrameworkCore;

using TravelBookingPortal.Domain.Enitites.ReviewEntities;
using TravelBookingPortal.Domain.Repositories.ReviewRepo;
using TravelBookingPortal.Infrastructure.DbContext;

namespace TravelBookingPortal.Infrastructure.Repositories.ReviewRepo
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly TravelBookingPortalDbContext context;

        public ReviewRepository(TravelBookingPortalDbContext _context)
        {
            context = _context;
        }

        public async Task AddAsync(Review review)
        {
            context.Reviews.Add(review);
            await context.SaveChangesAsync();
        }


        public async Task<List<Review>> GetByUserIdAsync(string userId)
        {
            return await context.Reviews.Where(U=>U.UserId == userId).ToListAsync();
        }

        public async Task<List<Review>> GetByHotelIdAsync(int hotelId)
        {
            return await context.Reviews
                .Include(m=>m.User)
                .Where(r => r.HotelId == hotelId)
                .ToListAsync();
        }


        public async Task DeleteAsync(int reviewId)
        {
            var review = await context.Reviews.FindAsync(reviewId);
            if (review != null)
            {
                context.Reviews.Remove(review);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Review review)
        {
            context.Reviews.Update(review);
            await context.SaveChangesAsync();
        }

        public Task<Review> GetByIdAsync(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
