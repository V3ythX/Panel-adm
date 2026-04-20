    using DTO.BookingStatus;
using DTO.Event;
using DTO.Payment;
using DTO.User;

namespace DTO.Booking;

public class BookingDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public UserForOtherDto? User { get; set; }
    public EventForOtherDto? Event { get; set; }
    public DateTime BookingDate { get; set; } //?
    public BookingStatusDto? BookingStatus { get; set; }
    public int NumberOfSeats { get; set; }
    public PaymentForOtherDto? Payment { get; set; }
}