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
        public Task AddAsync(Review review);

        public Task<List<Review>> GetByUserIdAsync(string userId);
    }
}
