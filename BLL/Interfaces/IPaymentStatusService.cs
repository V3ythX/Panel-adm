using DTO.PaymentStatus;

namespace BLL.Interfaces;

public interface IPaymentStatusService
{
    Task<List<PaymentStatusDto>> GetPaymentStatuses();
    Task<PaymentStatusDto> GetPaymentStatus(Guid Id);
    Task<PaymentStatusDto> CreatePaymentStatus(CreatePaymentStatusDto paymentStatus);
    Task<PaymentStatusDto> UpdatePaymentStatus(UpdatePaymentStatusDto paymentStatus);
    Task DeletePaymentStatus(Guid Id);

}