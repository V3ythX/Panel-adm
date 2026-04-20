namespace DTO.Event;

public class CreateEventDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public Guid LocationId { get; set; }
    public Guid UserId { get; set; }
    public Guid EventCategoryId { get; set; }
    
    public List<Guid> BookingsIds { get; set; } = new();
    public List<Guid> ReviewsIds { get; set; } = new();
}