using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.Event;
using DTO.Review;
using DTO.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ReviewRepository(ApplicationContext context):IReviewRepository
{
    public async Task<List<ReviewDto>> GetAll()
    {
        List<Review> reviews = await context.Reviews
            .Include(r => r.User)
            .Include(r => r.Event)
            .ToListAsync();
        List<ReviewDto> reviewList = new List<ReviewDto>();
        foreach (var review in reviews)
        {
            UserForOtherDto? userDto = null;
            if (review.User != null)
            {
                userDto = new UserForOtherDto()
                {
                    Id = review.UserId,
                    FirstName = review.User.FirstName,
                    LastName = review.User.LastName,
                    Patronymic = review.User.Patronymic,
                };
            }
            
            EventForOtherDto? eventDto = null;
            if (review.Event != null)
            {
                eventDto = new EventForOtherDto()
                {
                    Id = review.EventId,
                    Title = review.Event.Title,
                };
            }

            ReviewDto reviewDto = new()
            {
                Id = review.Id,
                Rating = review.Rating,
                Comment = review.Comment,
                User = userDto,
                Event = eventDto,
                CreatedAt = review.CreatedAt,
                UpdatedAt = review.UpdatedAt,
            };
            reviewList.Add(reviewDto);
        }
        return reviewList;
    }

    public async Task<ReviewDto> GetById(Guid id)
    {
        Review? review = await context.Reviews.FindAsync(id);
        
        UserForOtherDto? userDto = null;
        if (review.User != null)
        {
            userDto = new UserForOtherDto()
            {
                Id = review.UserId,
                FirstName = review.User.FirstName,
                LastName = review.User.LastName,
                Patronymic = review.User.Patronymic,
            };
        }
        EventForOtherDto? eventDto = null;
        if (review.Event != null)
        {
            eventDto = new EventForOtherDto()
            {
                Id = review.EventId,
                Title = review.Event.Title,
            };
        }

        return new ReviewDto()
        {
            Id = review.Id,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt,
            UpdatedAt = review.UpdatedAt,
            User = userDto,
            Event = eventDto,
        };
    }

    public async Task<ReviewDto> Create(CreateReviewDto review)
    {
        User? user = await context.Users.FirstOrDefaultAsync(r => r.Id == review.UserId);
        
        Event? reviewEvent = await context.Events.FirstOrDefaultAsync(e => e.Id == review.EventId);

        Review createReview = new()
        {
            Id = Guid.NewGuid(),
            User = user,
            Event = reviewEvent,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        context.Add(createReview);
        await context.SaveChangesAsync();

        UserForOtherDto? userDto = new()
        {
            Id = createReview.User.Id,
            FirstName = createReview.User.FirstName,
            LastName = createReview.User.LastName,
            Patronymic = createReview.User.Patronymic,
        };

        EventForOtherDto? eventDto = new()
        {
            Id = createReview.Event.Id,
            Title = createReview.Event.Title,
        };

        return new ReviewDto()
        {
            Id = createReview.Id,
            Rating = createReview.Rating,
            Comment = createReview.Comment,
            CreatedAt = createReview.CreatedAt,
            UpdatedAt = createReview.UpdatedAt,
            User = userDto,
            Event = eventDto,
        };
    }

    public async Task<ReviewDto> Update(UpdateReviewDto review)
    {
        Review? updatedReview = await context.Reviews.FindAsync(review.Id);
        User? user = await context.Users.FirstOrDefaultAsync(r => r.Id == review.UserId);
        Event? reviewEvent = await context.Events.FirstOrDefaultAsync(e => e.Id == review.EventId);
        
        updatedReview.Rating = review.Rating;
        updatedReview.Comment = review.Comment;
        updatedReview.UpdatedAt = DateTime.UtcNow;
        updatedReview.User = user;
        updatedReview.Event = reviewEvent;
        
        context.Update(updatedReview);
        await context.SaveChangesAsync();

        UserForOtherDto? userDto = new()
        {
            Id = updatedReview.User.Id,
            FirstName = updatedReview.User.FirstName,
            LastName = updatedReview.User.LastName,
            Patronymic = updatedReview.User.Patronymic,
        };

        EventForOtherDto? eventDto = new()
        {
            Id = updatedReview.Event.Id,
            Title = updatedReview.Event.Title,
        };

        return new ReviewDto()
        {
            Id = updatedReview.Id,
            Rating = updatedReview.Rating,
            Comment = updatedReview.Comment,
            CreatedAt = updatedReview.CreatedAt,
            UpdatedAt = updatedReview.UpdatedAt,
            User = userDto,
            Event = eventDto,
        };
    }

    public async Task Delete(Guid id)
    {
        Review? review = await context.Reviews.FindAsync(id);
        context.Reviews.Remove(review);
        await context.SaveChangesAsync();
    }
    
}