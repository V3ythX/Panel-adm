using DTO.Review;

namespace BLL.Interfaces;

public interface IReviewService
{
    Task<List<ReviewDto>> GetReviews();
    Task<ReviewDto> GetReview(Guid id);
    Task<ReviewDto> CreateReview(CreateReviewDto review);
    Task<ReviewDto> UpdateReview(UpdateReviewDto review);
    Task DeleteReview(Guid id);
}