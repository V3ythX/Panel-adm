using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.PaymentMethod;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class PaymentMethodRepository(ApplicationContext context) : IPaymentMethodRepository
{
    public async Task<List<PaymentMethodDto>> GetAll()
    {
        List<PaymentMethod> paymentMethods = await context.PaymentMethods.ToListAsync();
        List<PaymentMethodDto>paymentMethodList = new List<PaymentMethodDto>();
        foreach (var paymentMethod in paymentMethods)
        {
            PaymentMethodDto paymentMethodDto = new()
            {
                Id = paymentMethod.Id,
                Name = paymentMethod.Name,
                CreatedAt = paymentMethod.CreatedAt,
                UpdatedAt = paymentMethod.UpdatedAt,
            };
            paymentMethodList.Add(paymentMethodDto);
        }
        return paymentMethodList;
    }

    public async Task<PaymentMethodDto> GetById(Guid id)
    {
        PaymentMethod? paymentMethod = await context.PaymentMethods.FindAsync();
        return new PaymentMethodDto()
        {
            Id = paymentMethod.Id,
            Name = paymentMethod.Name,
            CreatedAt = paymentMethod.CreatedAt,
            UpdatedAt = paymentMethod.UpdatedAt,
        };
    }

    public async Task<PaymentMethodDto> Create(CreatePaymentMethodDto paymentMethod)
    {
        PaymentMethod createdPaymentMethod = new()
        {
            Name = paymentMethod.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        context.PaymentMethods.Add(createdPaymentMethod);
        await context.SaveChangesAsync();

        return new PaymentMethodDto()
        {
            Id = createdPaymentMethod.Id,
            Name = createdPaymentMethod.Name,
            CreatedAt = createdPaymentMethod.CreatedAt,
            UpdatedAt = createdPaymentMethod.UpdatedAt,
        };
    }

    public async Task<PaymentMethodDto> Update(UpdatePaymentMethodDto paymentMethod)
    {
        PaymentMethod? updatedPaymentMethod = await context.PaymentMethods.FindAsync(paymentMethod.Id);
        updatedPaymentMethod.Name = paymentMethod.Name;
        updatedPaymentMethod.UpdatedAt = DateTime.UtcNow;
        
        context.PaymentMethods.Update(updatedPaymentMethod);
        await context.SaveChangesAsync();

        return new PaymentMethodDto()
        {
            Id = updatedPaymentMethod.Id,
            Name = updatedPaymentMethod.Name,
            CreatedAt = updatedPaymentMethod.CreatedAt,
        };
    }

    public async Task Delete(Guid id)
    {
        PaymentMethod? paymentMethod = await context.PaymentMethods.FindAsync(id);
        context.PaymentMethods.Remove(paymentMethod);
        await context.SaveChangesAsync();
    }
}