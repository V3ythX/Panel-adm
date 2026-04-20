namespace DTO.Booking;

public class CreateBookingDto
{
    public Guid UserId { get; set; }
    public Guid? EventId { get; set; }
    public Guid BookingStatusId { get; set; }
    public int NumberOfSeats { get; set; }
    public Guid? PaymentId { get; set; }
}