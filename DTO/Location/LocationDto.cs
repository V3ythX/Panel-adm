using DTO.Event;

namespace DTO.Location;

public class LocationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public int NumberOfSeats { get; set; } 
    
    public List<EventForOtherDto>Event{get;set;}
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
}