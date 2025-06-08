using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Contract
{
    public interface IReviewService
    {
        Task<ResponseDTO> CreateReview(Review review);
        Task<ResponseDTO> GetReviewById(Guid reviewId);
        Task<ResponseDTO> GetAllReviews(int pageNumber, int pageSize);
        Task<ResponseDTO> UpdateReview(Review review);
        Task<ResponseDTO> DeleteReview(Guid reviewId);
    }
}
