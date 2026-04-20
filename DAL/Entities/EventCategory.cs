using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAL.Entities;

public class EventCategory:BaseEntity
{
    public string Name { get; set; }= string.Empty;
    
    public List<Event> Events { get; set; } = new List<Event>();
}

public class EventCategoryMap
{
    public EventCategoryMap(EntityTypeBuilder<EventCategory> builder)
    {
        builder.HasKey(ec => ec.Id);
        builder.Property(ec => ec.Name).IsRequired().HasMaxLength(50);
        builder.Property(ec => ec.CreatedAt).IsRequired();
        builder.Property(ec => ec.UpdatedAt).IsRequired();
        builder
            .HasMany(ec => ec.Events)
            .WithOne(ec => ec.EventCategory)
            .OnDelete(DeleteBehavior.SetNull);
    }
}