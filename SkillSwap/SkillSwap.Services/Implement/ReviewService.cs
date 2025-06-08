using SkillSwap.Commons.DTO;
using SkillSwap.Commons.DTO.BusinessCode;
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Model;
using SkillSwap.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwap.Services.Implement
{
    public class ReviewService : IReviewService
    {
        private readonly IGenericRepository<Review> _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(
            IGenericRepository<Review> reviewRepository,
            IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO> CreateReview(Review review)
        {
            var dto = new ResponseDTO();
            try
            {
                review.ReviewID = Guid.NewGuid();
                review.CreatedDate = DateTime.UtcNow;

                await _reviewRepository.Insert(review);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.INSERT_SUCESSFULLY;
                dto.Data = review;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetReviewById(Guid reviewId)
        {
            var dto = new ResponseDTO();
            try
            {
                var review = await _reviewRepository.GetById(reviewId);
                if (review == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = review;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> GetAllReviews(int pageNumber, int pageSize)
        {
            var dto = new ResponseDTO();
            try
            {
                var result = await _reviewRepository.GetAllDataByExpression(
                    filter: null,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    orderBy: r => r.CreatedDate,
                    isAscending: false,
                    includes: new System.Linq.Expressions.Expression<Func<Review, object>>[]
                    {
                            r => r.Order
                    }
                );

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.GET_DATA_SUCCESSFULLY;
                dto.Data = result;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> UpdateReview(Review review)
        {
            var dto = new ResponseDTO();
            try
            {
                var existing = await _reviewRepository.GetById(review.ReviewID);
                if (existing == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                existing.ReviewDetail = review.ReviewDetail;
                existing.Rating = review.Rating;
                existing.OrderID = review.OrderID;
                // Not update CreatedDate

                await _reviewRepository.Update(existing);
                await _unitOfWork.SaveChangeAsync();

                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.UPDATE_SUCCESSFULLY;
                dto.Data = existing;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }

        public async Task<ResponseDTO> DeleteReview(Guid reviewId)
        {
            var dto = new ResponseDTO();
            try
            {
                var deleted = await _reviewRepository.DeleteById(reviewId);
                if (deleted == null)
                {
                    dto.IsSucess = false;
                    dto.BusinessCode = BusinessCode.MESSAGE_NOT_FOUND;
                    return dto;
                }

                await _unitOfWork.SaveChangeAsync();
                dto.IsSucess = true;
                dto.BusinessCode = BusinessCode.CANCEL_SUCCESSFULLY;
            }
            catch
            {
                dto.IsSucess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return dto;
        }
    }
}
