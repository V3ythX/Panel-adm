using DTO.Booking;
using DTO.PaymentMethod;
using DTO.PaymentStatus;

namespace DTO.Payment;

public class PaymentDto
{
    public Guid Id { get; set; }
    public BookingForOtherDto? Booking { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatusDto? PaymentStatus { get; set; }
    public PaymentMethodDto? PaymentMethod { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}