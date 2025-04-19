using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingPortal.Domain.Enitites.ReviewEntities;

namespace TravelBookingPortal.Domain.Repositories.ReviewRepo
{
    public interface IReviewRepository
    {
        public Task AddAsync(Review review,string hotelName);

        public Task<List<Review>> GetByUserIdAsync(string userId);

        public Task<List<Review>> GetByHotelByNameAsync(string hotelName);

        public Task DeleteAsync(int reviewId);

        public Task UpdateAsync(Review review);
        Task<Review> GetByIdAsync(int reviewId);
    }
}
