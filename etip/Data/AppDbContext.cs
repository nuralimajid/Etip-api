using etip.Models;
using Microsoft.EntityFrameworkCore;

namespace etip.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<ParkingSession> ParkingSessions { get; set; }
    public DbSet<ParkingRate> ParkingRates { get; set; }
    public DbSet<Operator> Operators { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operator>()
            .HasMany(o=>o.TapInSessions)
            .WithOne(s=>s.InTapOperator)
            .HasForeignKey(h=>h.InTapOperatorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Operator>()
            .HasMany(o=>o.TapOutSessions)
            .WithOne(s=>s.OutTapOperator)
            .HasForeignKey(h=>h.OutTapOperatorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
}