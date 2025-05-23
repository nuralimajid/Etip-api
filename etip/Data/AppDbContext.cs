using etip.Models;
using Microsoft.EntityFrameworkCore;

namespace etip.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    #region Transaction

    public DbSet<ParkingSession> ParkingSessions { get; set; }

    #endregion

    #region Master Data

    public DbSet<ParkingRate> ParkingRates { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<StatusUser> StatusUsers { get; set; }
    public DbSet<Gate> Gates { get; set; }
    public DbSet<GatePaymentOption> GatePaymentOptions { get; set; }

    #endregion

    #region User

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(o => o.TapInSessions)
            .WithOne(s => s.EmployeeIn)
            .HasForeignKey(h => h.EmployeeInId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasMany(o => o.TapOutSessions)
            .WithOne(s => s.EmployeeOut)
            .HasForeignKey(h => h.EmployeeOutId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ParkingSession>()
            .HasOne(o => o.GateIn)
            .WithMany(s => s.ParkingSessions)
            .HasForeignKey(h => h.GateInId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ParkingSession>()
            .HasOne(o => o.GateOut)
            .WithMany(s => s.ParkingSessions)
            .HasForeignKey(h => h.GateOutId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ParkingSession>()
            .HasOne(o => o.Vehicle)
            .WithMany(s => s.ParkingSessions)
            .HasForeignKey(h => h.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ParkingSession>()
            .HasOne(o => o.ParkingRate)
            .WithMany(s => s.ParkingSessions)
            .HasForeignKey(h => h.ParkingRateId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<ParkingSession>()
            .HasOne(o => o.PaymentMethod)
            .WithMany(s => s.ParkingSessions)
            .HasForeignKey(h => h.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<GatePaymentOption>()
            .HasOne(o => o.Gate)
            .WithMany(s => s.GatePaymentOptions)
            .HasForeignKey(h => h.GateId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<GatePaymentOption>()
            .HasOne(o => o.PaymentMethod)
            .WithMany(s => s.GatePaymentOptions)
            .HasForeignKey(h => h.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<PaymentMethod>()
            .HasMany(o => o.GatePaymentOptions)
            .WithOne(s => s.PaymentMethod)
            .HasForeignKey(h => h.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<PaymentMethod>()
            .HasMany(o => o.ParkingSessions)
            .WithOne(s => s.PaymentMethod)
            .HasForeignKey(h => h.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Vehicle>()
            .HasMany(o => o.ParkingSessions)
            .WithOne(s => s.Vehicle)
            .HasForeignKey(h => h.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Position>()
            .HasMany(o => o.Employees)
            .WithOne(s => s.Position)
            .HasForeignKey(h => h.PositionId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<User>()
            .HasMany(o => o.UserRoles)
            .WithOne(s => s.User)
            .HasForeignKey(h => h.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Role>()
            .HasMany(o => o.UserRoles)
            .WithOne(s => s.Role)
            .HasForeignKey(h => h.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}