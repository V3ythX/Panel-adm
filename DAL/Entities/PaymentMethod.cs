using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

public class PaymentMethod:BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public List<Payment> Payments { get; set; } = new List<Payment>();
    
}

public class PaymentMethodMap
{
    public PaymentMethodMap(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.HasKey(pm => pm.Id);
        builder.Property(pm => pm.Name).IsRequired().HasMaxLength(50);
        builder.Property(pm => pm.CreatedAt).IsRequired();
        builder.Property(pm => pm.UpdatedAt).IsRequired();
        builder
            .HasMany(pm => pm.Payments)
            .WithOne(pm => pm.PaymentMethod)
            .OnDelete(DeleteBehavior.SetNull);
    }
    
}