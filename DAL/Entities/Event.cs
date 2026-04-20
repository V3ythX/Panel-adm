using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAL.Entities;

public class Event:BaseEntity
{
    public string Title { get; set; }= string.Empty;
    public string Description { get; set; }= string.Empty;
    
    public Location Location { get; set; }
    public Guid LocationId { get; set; }
    
    public DateTime StartTime {get; set;}
    public DateTime EndTime {get; set;}
    
    public User CreatedBy { get; set; }
    public Guid CreatedById { get; set; }
    
    public EventCategory EventCategory { get; set; }
    public Guid EventCategoryId { get; set; }
    
    public List<Booking> Bookings { get; set; } = new List<Booking>();
    
    public List<Review> Reviews { get; set; } = new List<Review>();
    
} 
public class EventMap
{
    public EventMap(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(300);
        builder.Property(e => e.LocationId).IsRequired();
        builder
            .HasOne(e => e.Location)
            .WithMany(l => l.Events)
            .HasForeignKey(e => e.LocationId);
        builder.Property(e => e.StartTime).IsRequired();
        builder.Property(e => e.EndTime).IsRequired();
        builder.Property(e => e.CreatedById).IsRequired();
        builder
            .HasOne(e => e.CreatedBy)
            .WithMany(u => u.Events)
            .HasForeignKey(e => e.CreatedById);
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();
        builder
            .HasOne(e => e.EventCategory)
            .WithMany(ec => ec.Events)
            .HasForeignKey(e => e.EventCategoryId);
        builder
            .HasMany(e => e.Bookings)
            .WithOne(b => b.Event)
            .OnDelete(DeleteBehavior.SetNull);
        builder
            .HasMany(e => e.Reviews)
            .WithOne(r => r.Event)
            .OnDelete(DeleteBehavior.SetNull);
    }
}