using etip.Models;
using Microsoft.EntityFrameworkCore;

namespace etip.Data;

public static class Seeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Roles.Any())
        {
            var Role = new List<Role>
            {
                new Role { Name = "admin"},
                new Role { Name = "petugas" },
            };
            context.Roles.AddRange(Role);
        }

        if (!context.ParkingRates.Any())
        {
            var rate = new ParkingRate
            {
                FirstHourRate = 3000,
                NextHourRate = 2000,
                DailyMaxRate = 15000,
                OverDuePenaltyPerDay = 10000,
                EffectiveFrom = DateTime.UtcNow
            };
            context.ParkingRates.Add(rate);
        }

        context.SaveChanges();
    }
}