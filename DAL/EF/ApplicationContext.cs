using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class ApplicationContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookingStatus> BookingStatuses { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<PaymentStatus> PaymentStatuses { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }
    
    public DbSet<LocationCategory> LocationCategories { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new BookingMap(modelBuilder.Entity<Booking>());
        new BookingStatusMap(modelBuilder.Entity<BookingStatus>());
        new EventMap(modelBuilder.Entity<Event>());
        new EventCategoryMap(modelBuilder.Entity<EventCategory>());
        new LocationMap(modelBuilder.Entity<Location>());
        new PaymentMap(modelBuilder.Entity<Payment>());
        new PaymentMethodMap(modelBuilder.Entity<PaymentMethod>());
        new PaymentStatusMap(modelBuilder.Entity<PaymentStatus>());
        new ReviewMap(modelBuilder.Entity<Review>());
        new UserMap(modelBuilder.Entity<User>());
        new LocationCategoryMap(modelBuilder.Entity<LocationCategory>());
    }
}