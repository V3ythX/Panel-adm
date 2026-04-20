using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTO.PaymentMethod;

namespace BLL.Services;

public class PaymentMethodService(IPaymentMethodRepository paymentMethodRepository):IPaymentMethodService
{
    public async Task<List<PaymentMethodDto>> GetPaymentMethods() => await paymentMethodRepository.GetAll();
    public async Task<PaymentMethodDto> GetPaymentMethod(Guid Id) => await paymentMethodRepository.GetById(Id);
    public async Task<PaymentMethodDto> CreatePaymentMethod(CreatePaymentMethodDto paymentMethod) => await paymentMethodRepository.Create(paymentMethod);
    public async Task<PaymentMethodDto> UpdatePaymentMethod(UpdatePaymentMethodDto paymentMethod) => await paymentMethodRepository.Update(paymentMethod);
    public async Task DeletePaymentMethod(Guid Id) => await paymentMethodRepository.Delete(Id);

}