using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

public class PaymentStatus:BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public List<Payment> Payments { get; set; } = new List<Payment>();
}

public class PaymentStatusMap
{
    public PaymentStatusMap(EntityTypeBuilder<PaymentStatus> builder)
    {
        builder.HasKey(ps => ps.Id);
        builder.Property(ps => ps.Name).IsRequired().HasMaxLength(50);
        builder.Property(ps => ps.CreatedAt).IsRequired();
        builder.Property(ps => ps.UpdatedAt).IsRequired();
        builder
            .HasMany(pm => pm.Payments)
            .WithOne(pm => pm.PaymentStatus)
            .OnDelete(DeleteBehavior.SetNull);
    }
}