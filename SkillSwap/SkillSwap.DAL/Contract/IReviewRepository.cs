using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Contract
{
    public interface IReviewRepository
    {
        Task<Review> CreateReview(Review review);
        Task<Review> UpdateReview(Guid id, Review review);
        Task<Review> DeleteReview(Guid id, Review review);
        Task<List<Review>> GetAllReviews();
        Task<List<Review>> GetReviewsByUserId(Guid userId);
    }
}
