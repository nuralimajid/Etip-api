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
            .WithOne(s=>s.EmployeeIn)
            .HasForeignKey(h=>h.EmployeeInId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Employee>()
            .HasMany(o=>o.TapOutSessions)
            .WithOne(s=>s.EmployeeOut)
            .HasForeignKey(h=>h.EmployeeOutId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
}