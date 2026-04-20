using DTO.Payment;

namespace DAL.Interfaces;

public interface IPaymentRepository: IRepository<PaymentDto, CreatePaymentDto, UpdatePaymentDto>
{
    
}