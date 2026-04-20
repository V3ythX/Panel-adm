using DTO.Payment;

namespace BLL.Interfaces;

public interface IPaymentService
{
    Task<List<PaymentDto>> GetPayments();
    Task<PaymentDto> GetPayment(Guid Id);
    Task<PaymentDto> CreatePayment(CreatePaymentDto payment);
    Task<PaymentDto> UpdatePayment(UpdatePaymentDto payment);
    Task DeletePayment(Guid Id);

}