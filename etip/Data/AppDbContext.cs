using etip.Models;
using Microsoft.EntityFrameworkCore;

namespace etip.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<ParkingSession> ParkingSessions { get; set; }
    public DbSet<ParkingRate> ParkingRates { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(o=>o.TapInSessions)
            .WithOne(s=>s.InTapEmployee)
            .HasForeignKey(h=>h.InTapOperatorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Employee>()
            .HasMany(o=>o.TapOutSessions)
            .WithOne(s=>s.OutTapEmployee)
            .HasForeignKey(h=>h.OutTapOperatorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
}