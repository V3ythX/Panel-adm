using BLL.Interfaces;
using DTO.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;
[ApiController]
[Route("reviews")]
public class ReviewController(IReviewService reviewService):ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<ReviewDto>>> GetReviews() => Ok(await reviewService.GetReviews());
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDto>> GetReview(Guid id)=> Ok(await reviewService.GetReview(id));
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ReviewDto>> CreateReview([FromBody]CreateReviewDto review)=> Ok(await reviewService.CreateReview(review));
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<ReviewDto>> UpdateReview(Guid id, [FromBody] UpdateReviewDto review)
    {
        review.Id = id;
        
        return Ok(await reviewService.UpdateReview(review));
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteReview(Guid id)
    {
        await reviewService.DeleteReview(id);
        return Ok();
    }
}