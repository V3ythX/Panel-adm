namespace DTO.Payment;

public class UpdatePaymentDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public Guid PaymentStatusId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public Guid BookingId { get; set; }
}