using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DTO.Booking;
using DTO.Payment;
using DTO.PaymentMethod;
using DTO.PaymentStatus;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class PaymentRepository(ApplicationContext context): IPaymentRepository
{
    public async Task<List<PaymentDto>> GetAll()
    {
        List<Payment> payments = await context.Payments
            .Include(p => p.PaymentStatus)
            .Include(p => p.PaymentMethod)
            .Include(p => p.Booking)
            .ToListAsync();
        List<PaymentDto> paymentList = new List<PaymentDto>();

        foreach (var payment in payments)
        {

            BookingForOtherDto? bookingDto = null;
            if (payment.Booking != null)
            {
                bookingDto = new BookingForOtherDto()
                {
                    Id = payment.Booking.Id,
                    NumberOfSeats = payment.Booking.NumberOfSeats,
                };
            }
            PaymentMethodDto? paymentMethodDto = null;
            if (payment.PaymentMethod != null)
            {
                paymentMethodDto = new PaymentMethodDto()
                {
                    Id = payment.PaymentMethod.Id,
                    Name = payment.PaymentMethod.Name,
                };
            }
            PaymentStatusDto? paymentStatusDto = null;
            if (payment.PaymentStatus != null)
            {
                paymentStatusDto = new PaymentStatusDto()
                {
                    Id = payment.PaymentStatus.Id,
                    Name = payment.PaymentStatus.Name,
                };
            }

            PaymentDto paymentDto = new()
            {
                Id = payment.Id,
                Amount = payment.Amount,
                PaymentMethod = paymentMethodDto,
                PaymentStatus = paymentStatusDto,
                Booking = bookingDto,
                PaymentDate = payment.PaymentDate,
                CreatedAt = payment.CreatedAt,
                UpdatedAt = payment.UpdatedAt,
            };
            paymentList.Add(paymentDto);
        }
        return paymentList;
    }

    public async Task<PaymentDto> GetById(Guid id)
    {
        Payment? payment = await context.Payments.FindAsync(id);
        
        
        BookingForOtherDto? bookingDto = null;
        if (payment.Booking != null)
        {
            bookingDto = new BookingForOtherDto()
            {
                Id = payment.Booking.Id,
                NumberOfSeats = payment.Booking.NumberOfSeats,
            };
        }
        
        PaymentMethodDto? paymentMethodDto = null;
        if (payment.PaymentMethod != null)
        {
            paymentMethodDto = new PaymentMethodDto()
            {
                Id = payment.PaymentMethod.Id,
                Name = payment.PaymentMethod.Name,
            };
        }
        
        PaymentStatusDto? paymentStatusDto = null;
        if (payment.PaymentStatus != null)
        {
            paymentStatusDto = new PaymentStatusDto()
            {
                Id = payment.PaymentStatus.Id,
                Name = payment.PaymentStatus.Name,
            };
        }

        return new PaymentDto()
        {
            Id = payment.Id,
            Amount = payment.Amount,
            PaymentMethod = paymentMethodDto,
            PaymentStatus = paymentStatusDto,
            Booking = bookingDto,
            PaymentDate = payment.PaymentDate,
            CreatedAt = payment.CreatedAt,
            UpdatedAt = payment.UpdatedAt,
        };
    }

    public async Task<PaymentDto> Create(CreatePaymentDto payment)
    {
        Booking? booking = await context.Bookings
            .FirstOrDefaultAsync(b => b.Id == payment.BookingId);
        PaymentMethod? paymentMethod = await context.PaymentMethods
            .FirstOrDefaultAsync(p => p.Id == payment.PaymentMethodId);
        PaymentStatus? paymentStatus = await context.PaymentStatuses
            .FirstOrDefaultAsync(p => p.Id == payment.PaymentStatusId);

        Payment createPayment = new()
        {
            Booking = booking,
            PaymentMethod = paymentMethod,
            PaymentStatus = paymentStatus,
            PaymentDate = payment.PaymentDate,
            Amount = payment.Amount,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        context.Payments.Add(createPayment);
        await context.SaveChangesAsync();

        BookingForOtherDto? bookingDto = new()
        {
            Id = createPayment.Booking.Id,
            NumberOfSeats = createPayment.Booking.NumberOfSeats,
        };

        PaymentMethodDto? paymentMethodDto = new()
        {
            Id = createPayment.PaymentMethod.Id,
            Name = createPayment.PaymentMethod.Name,
        };
        PaymentStatusDto? paymentStatusDto = new()
        {
            Id = createPayment.PaymentStatus.Id,
            Name = createPayment.PaymentStatus.Name,
        };
        return new PaymentDto()
        {
            Id = createPayment.Id,
            Amount = createPayment.Amount,
            PaymentMethod = paymentMethodDto,
            PaymentStatus = paymentStatusDto,
            Booking = bookingDto,
            PaymentDate = createPayment.PaymentDate,
            CreatedAt = createPayment.CreatedAt,
            UpdatedAt = createPayment.UpdatedAt,
        };
    }

    public async Task<PaymentDto> Update(UpdatePaymentDto payment)
    {
        Payment? updatePayment = await context.Payments.FindAsync(payment.Id);
        
        Booking? booking = await context.Bookings
            .FirstOrDefaultAsync(b => b.Id == payment.BookingId);
        PaymentMethod? paymentMethod = await context.PaymentMethods
            .FirstOrDefaultAsync(p => p.Id == payment.PaymentMethodId);
        PaymentStatus? paymentStatus = await context.PaymentStatuses
            .FirstOrDefaultAsync(p => p.Id == payment.PaymentStatusId);
        
        updatePayment.PaymentMethod = paymentMethod;
        updatePayment.PaymentStatus = paymentStatus;
        updatePayment.Booking = booking;
        updatePayment.PaymentDate = payment.PaymentDate;
        updatePayment.Amount = payment.Amount;
        updatePayment.UpdatedAt = DateTime.UtcNow;
        
        context.Payments.Update(updatePayment);
        await context.SaveChangesAsync();

        BookingForOtherDto? bookingDto = new()
        {
            Id = updatePayment.Booking.Id,
            NumberOfSeats = updatePayment.Booking.NumberOfSeats,
        };

        PaymentMethodDto? paymentMethodDto = new()
        {
            Id = updatePayment.PaymentMethod.Id,
            Name = updatePayment.PaymentMethod.Name,
        };

        PaymentStatusDto? paymentStatusDto = new()
        {
            Id = updatePayment.PaymentStatus.Id,
            Name = updatePayment.PaymentStatus.Name,
        };

        return new PaymentDto()
        {
            Id = updatePayment.Id,
            Amount = updatePayment.Amount,
            PaymentDate = updatePayment.PaymentDate,
            Booking = bookingDto,
            PaymentMethod = paymentMethodDto,
            PaymentStatus = paymentStatusDto,
            CreatedAt = updatePayment.CreatedAt,
            UpdatedAt = updatePayment.UpdatedAt,
        };
    }

    public async Task Delete(Guid id)
    {
        Payment? payment = await context.Payments.FindAsync(id);
        context.Payments.Remove(payment);
        await context.SaveChangesAsync();
    }
}