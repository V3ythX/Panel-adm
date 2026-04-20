using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

public class LocationCategory:BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public List<Location> Locations { get; set; } = new List<Location>();
}

public class LocationCategoryMap
{
    public LocationCategoryMap(EntityTypeBuilder<LocationCategory> builder)
    {
        builder.HasKey(lc => lc.Id);
        builder.Property(lc => lc.Name).HasMaxLength(100).IsRequired();
        builder.Property(lc => lc.CreatedAt).IsRequired();
        builder.Property(lc => lc.UpdatedAt).IsRequired();
        builder
            .HasMany(lc => lc.Locations)
            .WithOne(lc => lc.LocationCategory)
            .OnDelete(DeleteBehavior.SetNull);
    }
}