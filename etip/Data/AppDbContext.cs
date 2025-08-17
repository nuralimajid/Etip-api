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
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GatePaymentOption>()
            .HasKey(gpo => new { gpo.GateId, gpo.PaymentMethodId });

        modelBuilder.Entity<GatePaymentOption>()
            .HasOne(gpo => gpo.Gate)
            .WithMany(g => g.GatePaymentOptions)
            .HasForeignKey(gpo => gpo.GateId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GatePaymentOption>()
            .HasOne(gpo => gpo.PaymentMethod)
            .WithMany(p => p.GatePaymentOptions)
            .HasForeignKey(gpo => gpo.PaymentMethodId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.TapInSessions)
            .WithOne(ps => ps.EmployeeIn)
            .HasForeignKey(ps => ps.EmployeeInId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.TapOutSessions)
            .WithOne(ps => ps.EmployeeOut)
            .HasForeignKey(ps => ps.EmployeeOutId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<ParkingSession>()
            .HasOne(ps => ps.GateIn)
            .WithMany(g => g.ParkingSessionsIn)
            .HasForeignKey(ps => ps.GateInId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ParkingSession>()
            .HasOne(ps => ps.GateOut)
            .WithMany(g => g.ParkingSessionsOut)
            .HasForeignKey(ps => ps.GateOutId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Position>()
            .HasMany(p => p.Employees)
            .WithOne(e => e.Position)
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}