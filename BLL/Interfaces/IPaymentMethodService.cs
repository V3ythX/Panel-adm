using DTO.PaymentMethod;

namespace BLL.Interfaces;

public interface IPaymentMethodService
{
    Task<List<PaymentMethodDto>> GetPaymentMethods();
    Task<PaymentMethodDto> GetPaymentMethod(Guid Id);
    Task<PaymentMethodDto> CreatePaymentMethod(CreatePaymentMethodDto paymentMethod);
    Task<PaymentMethodDto> UpdatePaymentMethod(UpdatePaymentMethodDto paymentMethod);
    Task DeletePaymentMethod(Guid Id);
}