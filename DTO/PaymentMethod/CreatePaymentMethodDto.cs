namespace DTO.PaymentMethod;

public class CreatePaymentMethodDto
{
    public string Name { get; set; } = string.Empty;
    public List<Guid> PaymentsIds { get; set; } = new();
}