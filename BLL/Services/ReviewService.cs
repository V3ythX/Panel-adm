using BLL.Interfaces;
using DAL.Interfaces;
using DTO.Review;

namespace BLL.Services;

public class ReviewService(IReviewRepository reviewRepository) : IReviewService
{
    public async Task<List<ReviewDto>> GetReviews() => await reviewRepository.GetAll();
    public async Task<ReviewDto> GetReview(Guid id) => await reviewRepository.GetById(id);
    public async Task<ReviewDto> CreateReview(CreateReviewDto review)=> await reviewRepository.Create(review);
    public async Task<ReviewDto> UpdateReview(UpdateReviewDto review) => await reviewRepository.Update(review);
    public async Task DeleteReview(Guid id) => await reviewRepository.Delete(id);
}