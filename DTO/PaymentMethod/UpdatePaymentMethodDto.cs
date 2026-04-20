namespace DTO.PaymentMethod;

public class UpdatePaymentMethodDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Guid> PaymentsIds { get; set; } = new();
}