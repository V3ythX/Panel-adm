using BLL.Interfaces;
using DAL.Interfaces;
using DTO.Payment;

namespace BLL.Services;

public class PaymentService(IPaymentRepository paymentRepository): IPaymentService
{
    public async Task<List<PaymentDto>> GetPayments() => await paymentRepository.GetAll();
    public async Task<PaymentDto> GetPayment(Guid Id) => await paymentRepository.GetById(Id);
    public async Task<PaymentDto> CreatePayment(CreatePaymentDto payment) => await paymentRepository.Create(payment);
    public async Task<PaymentDto> UpdatePayment(UpdatePaymentDto payment) => await paymentRepository.Update(payment);
    public async Task DeletePayment(Guid Id) => await paymentRepository.Delete(Id);
}