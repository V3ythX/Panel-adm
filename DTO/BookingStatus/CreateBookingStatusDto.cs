namespace DTO.BookingStatus;

public class CreateBookingStatusDto
{
    public string Name { get; set; } = string.Empty;
    
    public List<Guid> BookingsIds { get; set; } = new ();
}