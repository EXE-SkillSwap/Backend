using Microsoft.AspNetCore.Mvc;
using SkillSwap.Commons.DTO;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;

namespace SkillSwap.API.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("create")]
        public async Task<ResponseDTO> CreateReview([FromBody] Review review)
        {
            return await _reviewService.CreateReview(review);
        }

        [HttpGet("get")]
        public async Task<ResponseDTO> GetReviewById([FromQuery] Guid reviewId)
        {
            return await _reviewService.GetReviewById(reviewId);
        }

        [HttpGet("all")]
        public async Task<ResponseDTO> GetAllReviews([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return await _reviewService.GetAllReviews(pageNumber, pageSize);
        }

        [HttpPut("update")]
        public async Task<ResponseDTO> UpdateReview([FromBody] Review review)
        {
            return await _reviewService.UpdateReview(review);
        }

        [HttpDelete("delete")]
        public async Task<ResponseDTO> DeleteReview([FromQuery] Guid reviewId)
        {
            return await _reviewService.DeleteReview(reviewId);
        }
    }
}
