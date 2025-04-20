using Microsoft.EntityFrameworkCore;
using ReviewEntities = TravelBookingPortal.Domain.Entites.Review.ReviewEntities;
using TravelBookingPortal.Application.Interfaces.Repositories.Review;
using TravelBookingPortal.Persistence.Persistence;

namespace TravelBookingPortal.Persistence.Repositories.Review
{
    public class ReviewRepository(TravelBookingPortalDbContext _context) : IReviewRepository
    {
        public async Task AddAsync(ReviewEntities review, string hotelName)
        {
            var hotel = await _context.Hotels
          .FirstOrDefaultAsync(h => h.Name == hotelName);
            review.HotelId = hotel.HotelId;
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }


        public async Task<List<ReviewEntities>> GetByUserIdAsync(string userId)
        {
            return await _context.Reviews.Where(U => U.UserId == userId).Include(m => m.User)
                            .Include(r => r.Hotel)
                            .ToListAsync();
        }

        public async Task<List<ReviewEntities>> GetByHotelByNameAsync(string hotelName)
        {
            return await _context.Reviews
                .Include(m => m.User)
                .Include(r => r.Hotel)
                .Where(r => r.Hotel.Name == hotelName)
                .ToListAsync();
        }


        public async Task DeleteAsync(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(ReviewEntities review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public Task<ReviewEntities> GetByIdAsync(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
