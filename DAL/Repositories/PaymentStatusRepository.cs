using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.PaymentStatus;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class PaymentStatusRepository(ApplicationContext context):IPaymentStatusRepository
{
    public async Task<List<PaymentStatusDto>> GetAll()
    {
        List<PaymentStatus> paymentStatuses = await context.PaymentStatuses.ToListAsync();
        List<PaymentStatusDto>paymentStatusList = new List<PaymentStatusDto>();
        foreach (var paymentStatus in paymentStatuses)
        {
            PaymentStatusDto paymentStatusDto = new()
            {
                Id = paymentStatus.Id,
                Name = paymentStatus.Name,
                CreatedAt = paymentStatus.CreatedAt,
                UpdatedAt = paymentStatus.UpdatedAt,
            };
            paymentStatusList.Add(paymentStatusDto);
        }
        return paymentStatusList;
    }

    public async Task<PaymentStatusDto> GetById(Guid id)
    {
        PaymentStatus? paymentStatus = await context.PaymentStatuses.FindAsync();
        return new PaymentStatusDto()
        {
            Id = paymentStatus.Id,
            Name = paymentStatus.Name,
            CreatedAt = paymentStatus.CreatedAt,
            UpdatedAt = paymentStatus.UpdatedAt,
        };
    }

    public async Task<PaymentStatusDto> Create(CreatePaymentStatusDto paymentStatus)
    {
        PaymentStatus createpaymentStatus = new()
        {
            Name = paymentStatus.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        context.PaymentStatuses.Add(createpaymentStatus);
        await context.SaveChangesAsync();

        return new PaymentStatusDto()
        {
            Id = createpaymentStatus.Id,
            Name = createpaymentStatus.Name,
            CreatedAt = createpaymentStatus.CreatedAt,
            UpdatedAt = createpaymentStatus.UpdatedAt,
        };
    }

    public async Task<PaymentStatusDto> Update(UpdatePaymentStatusDto paymentStatus)
    {
        PaymentStatus? updatepaymentStatus = await context.PaymentStatuses.FindAsync(paymentStatus.Id);
        updatepaymentStatus.Name = paymentStatus.Name;
        updatepaymentStatus.UpdatedAt = DateTime.UtcNow;
        
        context.PaymentStatuses.Update(updatepaymentStatus);
        await context.SaveChangesAsync();

        return new PaymentStatusDto()
        {
            Id = updatepaymentStatus.Id,
            Name = updatepaymentStatus.Name,
            CreatedAt = updatepaymentStatus.CreatedAt,
            UpdatedAt = updatepaymentStatus.UpdatedAt,
        };
    }

    public async Task Delete(Guid id)
    {
        PaymentStatus? paymentStatus = await context.PaymentStatuses.FindAsync(id);
        context.PaymentStatuses.Remove(paymentStatus);
        await context.SaveChangesAsync();
    }
    
}