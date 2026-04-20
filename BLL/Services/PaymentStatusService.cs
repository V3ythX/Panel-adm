using BLL.Interfaces;
using DAL.Interfaces;
using DTO.PaymentStatus;

namespace BLL.Services;

public class PaymentStatusService(IPaymentStatusRepository paymentStatusRepository): IPaymentStatusService
{
    public async Task<List<PaymentStatusDto>> GetPaymentStatuses() => await paymentStatusRepository.GetAll();
    public async Task<PaymentStatusDto> GetPaymentStatus(Guid Id) => await paymentStatusRepository.GetById(Id);
    public async Task<PaymentStatusDto> CreatePaymentStatus(CreatePaymentStatusDto paymentStatus) => await paymentStatusRepository.Create(paymentStatus);
    public async Task<PaymentStatusDto> UpdatePaymentStatus(UpdatePaymentStatusDto paymentStatus) => await paymentStatusRepository.Update(paymentStatus);
    public async Task DeletePaymentStatus(Guid Id) => await paymentStatusRepository.Delete(Id);
    
}