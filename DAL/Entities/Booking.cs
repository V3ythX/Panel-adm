using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

public class Booking:BaseEntity
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    
    public Event Event { get; set; }
    public Guid EventId { get; set; }
    
    public DateTime BookingDate { get; set; } //Вопрос. А надо ли нам это поле, если у нас по умолчанию есть CreatedAt, которое показывает, когда создана запись о бронировании?
    
    public BookingStatus BookingStatus { get; set; }
    public Guid BookingStatusId { get; set; }
    
    public int NumberOfSeats { get; set; }
    
    public Payment Payment { get; set; }
    public Guid PaymentId { get; set; }
}
public class BookingMap
{
    public BookingMap(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserId).IsRequired();
        builder
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId);
        builder.Property(b => b.EventId).IsRequired();
        builder
            .HasOne(b => b.Event)
            .WithMany(e => e.Bookings)
            .HasForeignKey(b => b.EventId);
        builder.Property(b => b.BookingDate).IsRequired();
        builder.Property(b => b.NumberOfSeats).IsRequired().HasDefaultValue(1);
        builder.Property(b => b.BookingStatusId).IsRequired();
        builder
            .HasOne(b => b.BookingStatus)
            .WithMany(bs => bs.Bookings)
            .HasForeignKey(b => b.BookingStatusId);
        builder.Property(b => b.CreatedAt).IsRequired();
        builder.Property(b => b.UpdatedAt).IsRequired();
        builder.Property(b => b.PaymentId);
        builder
            .HasOne(b => b.Payment)
            .WithOne(p => p.Booking)
            .OnDelete(DeleteBehavior.SetNull);
    }
}