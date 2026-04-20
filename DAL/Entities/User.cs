using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

public class User: BaseEntity
{
   
   public string FirstName { get; set; } = string.Empty;
   public string LastName { get; set; } = string.Empty;
   public string? Patronymic { get; set; } = string.Empty;
   public string Email { get; set; }
   public string Phone { get; set; }
   public string Password { get; set; }
   public bool IsAdmin { get; set; }
   
   public List<Booking> Bookings { get; set; }
   public List<Event> Events { get; set; }
   
   public List<Review> Reviews { get; set; }
}
public class UserMap
{
   public UserMap(EntityTypeBuilder<User> builder)
   {
      builder.HasKey(u => u.Id);
      builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
      builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
      builder.Property(u => u.Patronymic).HasMaxLength(20); //это поле необязательно 
      builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
      builder.Property(u => u.Phone).IsRequired().HasMaxLength(20);
      builder.Property(u => u.Password).IsRequired().HasMaxLength(255);
      builder.Property(u => u.IsAdmin).IsRequired().HasDefaultValue(false); 
      builder.Property(u => u.CreatedAt).IsRequired();
      builder.Property(u => u.UpdatedAt).IsRequired();
      builder
         .HasMany(u => u.Bookings)
         .WithOne(b => b.User)
         .OnDelete(DeleteBehavior.SetNull);
      builder
         .HasMany(u => u.Events)
         .WithOne(e => e.CreatedBy)
         .OnDelete(DeleteBehavior.SetNull);
      builder
         .HasMany(u => u.Reviews)
         .WithOne(r => r.User)
         .OnDelete(DeleteBehavior.SetNull);
   }

}
