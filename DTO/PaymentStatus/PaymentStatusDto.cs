using DTO.Payment;

namespace DTO.PaymentStatus;

public class PaymentStatusDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<PaymentForOtherDto>Payment { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
}