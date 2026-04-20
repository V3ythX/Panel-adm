using DTO.Event;

namespace DTO.EventCategory;

public class EventCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public List<EventForOtherDto>Event { get; set; }
    
    public DateTime CreatedAt{ get; set; }
    public DateTime UpdatedAt { get; set; }
}