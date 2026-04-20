using DTO.Review;

namespace DAL.Interfaces;

public interface IReviewRepository:IRepository<ReviewDto, CreateReviewDto, UpdateReviewDto>
{
    
}