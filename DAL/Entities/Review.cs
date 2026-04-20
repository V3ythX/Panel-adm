using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

public class Review:BaseEntity
{
    public User User { get; set; } 
    public Guid UserId { get; set; }
    
    public Event Event { get; set; }
    public Guid EventId { get; set; }
    
    public short Rating { get; set; }
    
    public string? Comment { get; set; } = string.Empty;
}

public class ReviewMap
{
    public ReviewMap(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Comment).HasMaxLength(500);
        builder.Property(r => r.Rating).IsRequired();
        builder.Property(r => r.CreatedAt).IsRequired();
        builder.Property(r => r.UpdatedAt).IsRequired();
        builder.Property(r => r.UserId).IsRequired();
        builder
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);
        builder
            .HasOne(r => r.Event)
            .WithMany(e => e.Reviews)
            .HasForeignKey(r => r.EventId);
    }
}