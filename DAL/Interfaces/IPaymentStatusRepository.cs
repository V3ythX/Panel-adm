using DAL.Entities;
using DTO.PaymentStatus;

namespace DAL.Interfaces;

public interface IPaymentStatusRepository:IRepository<PaymentStatusDto, CreatePaymentStatusDto, UpdatePaymentStatusDto>
{
    
}