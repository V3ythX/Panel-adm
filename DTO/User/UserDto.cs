using DTO.Booking;
using DTO.Event;
using DTO.Review;

namespace DTO.User;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Patronymic { get; set; } = string.Empty;
    public string Email { get; set; }
    public string Phone { get; set; } 
    public string Password { get; set; } 
    public bool IsAdmin { get; set; }
    
    public List<BookingForOtherDto> Booking{get;set;}
    public List<EventForOtherDto> Event{get;set;}
    public List<ReviewForOtherDto> Review{get;set;}
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
}