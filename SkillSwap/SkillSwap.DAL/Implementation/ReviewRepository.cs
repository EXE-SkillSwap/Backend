using Microsoft.EntityFrameworkCore;
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Data;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.DAL.Implementation
{
    public class ReviewRepository : IReviewRepository
    {
        private SwapSkillDBContext _context;
        public ReviewRepository(SwapSkillDBContext context)
        {
            _context = context;
        }

        public async Task<Review> CreateReview(Review review)
        {
            review.ReviewID = Guid.NewGuid();
            review.CreatedDate = DateTime.UtcNow;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<List<Review>> GetAllReviews()
        {
            return await _context.Reviews
                .Include(r => r.Order)
                .ToListAsync();
        }

        public Task<Review> DeleteReview(Guid id, Review review)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetReviewsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Review> UpdateReview(Guid id, Review review)
        {
            var existing = await _context.Reviews.FindAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Review not found");

            existing.ReviewDetail = review.ReviewDetail;
            existing.Rating = review.Rating;
            //existing.OrderID = review.OrderID;
            // Do not update CreatedDate and OrderID

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
