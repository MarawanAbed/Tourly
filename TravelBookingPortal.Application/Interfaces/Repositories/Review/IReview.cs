using ReviewEntities = TravelBookingPortal.Domain.Entites.Review.ReviewEntities;

namespace TravelBookingPortal.Application.Interfaces.Repositories.Review
{
    public interface IReviewRepository
    {
        public Task AddAsync(ReviewEntities review, string hotelName);

        public Task<List<ReviewEntities>> GetByUserIdAsync(string userId);

        public Task<List<ReviewEntities>> GetByHotelByNameAsync(string hotelName);

        public Task DeleteAsync(int reviewId);

        public Task UpdateAsync(ReviewEntities review);
        public Task<ReviewEntities> GetByIdAsync(int reviewId);

    }
}
