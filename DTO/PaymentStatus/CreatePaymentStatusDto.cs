namespace DTO.PaymentStatus;

public class CreatePaymentStatusDto
{
    public string Name { get; set; } = string.Empty;
    public List<Guid> PaymentsIds { get; set; } = new();
}