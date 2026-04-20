using DTO.Booking;
using DTO.EventCategory;
using DTO.Location;
using DTO.Review;
using DTO.User;

namespace DTO.Event;

public class EventDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public LocationDto? Location { get; set; }
    public UserForOtherDto? User { get; set; }
    public EventCategoryDto? EventCategory { get; set; }
    
    public List<BookingForOtherDto> Booking { get; set; } 
    
    public List<ReviewForOtherDto> Review { get; set; }
    
}