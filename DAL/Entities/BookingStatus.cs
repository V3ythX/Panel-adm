using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

public class BookingStatus:BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public List<Booking> Bookings { get; set; } = new List<Booking>();
}

public class BookingStatusMap
{
    public BookingStatusMap(EntityTypeBuilder<BookingStatus> builder)
    {
        builder.HasKey(bs => bs.Id);
        builder.Property(bs => bs.Name).IsRequired().HasMaxLength(50);
        builder.Property(bs => bs.CreatedAt).IsRequired();
        builder.Property(bs => bs.UpdatedAt).IsRequired();
        builder
            .HasMany(bs => bs.Bookings)
            .WithOne(b => b.BookingStatus)
            .OnDelete(DeleteBehavior.SetNull);
    }
}