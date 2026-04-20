using DTO.Event;
using DTO.User;

namespace DTO.Review;

public class ReviewDto
{
    public Guid Id { get; set; }
    public UserForOtherDto? User { get; set; }
    public EventForOtherDto? Event { get; set; }
    public short Rating { get; set; }
    public string? Comment { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}