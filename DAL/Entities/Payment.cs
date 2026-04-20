using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

public class Payment:BaseEntity
{
   public Booking Booking { get; set; } 
   public Guid BookingId { get; set; }
    
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get;set; }
    
    
    public PaymentMethod PaymentMethod { get; set; }
    public Guid PaymentMethodId { get; set; }
    
    
    public PaymentStatus PaymentStatus { get; set; }
    public Guid PaymentStatusId { get; set; }
    
}

public class PaymentMap
{
    public PaymentMap(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.BookingId).IsRequired();
        builder.HasOne(p => p.Booking)
            .WithOne(b => b.Payment)
            .HasForeignKey<Payment>(p => p.BookingId); 
        builder.Property(p => p.Amount).IsRequired();
        builder.Property(p => p.PaymentDate).IsRequired();
        builder.Property(p => p.PaymentMethodId).IsRequired();
        builder
            .HasOne(p => p.PaymentMethod)
            .WithMany(pm => pm.Payments)
            .HasForeignKey(p => p.PaymentMethodId);
        builder.Property(p => p.PaymentStatusId).IsRequired();
        builder
            .HasOne(p => p.PaymentStatus)
            .WithMany(ps => ps.Payments)
            .HasForeignKey(p => p.PaymentStatusId);
        builder.Property(p => p.CreatedAt).IsRequired();
        builder.Property(p => p.UpdatedAt).IsRequired();
    }
}