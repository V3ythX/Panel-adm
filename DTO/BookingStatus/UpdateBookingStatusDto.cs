namespace DTO.BookingStatus;

public class UpdateBookingStatusDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Guid> BookingsIds { get; set; } = new ();
}