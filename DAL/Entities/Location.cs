using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

public class Location:BaseEntity
{
    public string Name{ get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public int NumberOfSeats { get; set; }
    
    public List<Event> Events { get; set; } = new List<Event>();
    
    public LocationCategory LocationCategory { get; set; }
    public Guid LocationCategoryId { get; set; }
}

public class LocationMap
{
    public LocationMap(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Name).IsRequired().HasMaxLength(50);
        builder.Property(l => l.Address).IsRequired().HasMaxLength(100);
        builder.Property(l => l.NumberOfSeats).IsRequired().HasDefaultValue(1);
        builder.Property(l => l.CreatedAt).IsRequired();
        builder.Property(l => l.UpdatedAt).IsRequired();
        builder
            .HasMany(l => l.Events)
            .WithOne(e => e.Location)
            .OnDelete(DeleteBehavior.SetNull);
        builder
            .HasOne(l => l.LocationCategory)
            .WithMany(lc => lc.Locations)
            .HasForeignKey(l => l.LocationCategoryId);

    }
}