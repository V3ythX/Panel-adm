using DTO.Booking;

namespace DTO.BookingStatus;

public class BookingStatusDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public List<BookingForOtherDto>Booking{get;set;}
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}