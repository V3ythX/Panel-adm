using DAL.Entities;
using DTO.PaymentMethod;

namespace DAL.Interfaces;

public interface IPaymentMethodRepository:IRepository<PaymentMethodDto, CreatePaymentMethodDto, UpdatePaymentMethodDto>
{
    
}