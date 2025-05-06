using etip.Models;
using Microsoft.EntityFrameworkCore;

namespace etip.Data;

public static class Seeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Operators.Any())
        {
            var Operators = new List<Operator>
            {
                new Operator { Name = "Budi", Code = "ET001", Gate = "Masuk" },
                new Operator { Name = "Sari", Code = "ET002", Gate = "Keluar" },
            };
            context.Operators.AddRange(Operators);
        }

        if (!context.ParkingRates.Any())
        {
            var rate = new ParkingRate
            {
                FirstHourRate = 3000,
                NextHourRate = 2000,
                DailyMaxRate = 15000,
                OverDuePinaltyPerDay = 10000,
                EffectiveFrom = DateTime.UtcNow
            };
            context.ParkingRates.Add(rate);
        }

        context.SaveChanges();
    }
}