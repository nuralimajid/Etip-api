using etip.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace etip.Data
{
    public static class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name = "admin"},
                    new Role { Name = "petugas" },
                };
                context.Roles.AddRange(roles);
            }

            if (!context.ParkingRates.Any())
            {
                var rate = new ParkingRate
                {
                    FirstHourRate = 3000,
                    NextHourRate = 2000,
                    DailyMaxRate = 15000,
                    OverDuePenaltyPerDay = 10000,
                    EffectiveFrom = System.DateTime.UtcNow
                };
                context.ParkingRates.Add(rate);
            }

            if (!context.PaymentMethods.Any())
            {
                var paymentMethods = new List<PaymentMethod>
                {
                    new PaymentMethod { Name = "Cash", Type = "Cash", IsActive = true },
                    new PaymentMethod { Name = "E-Wallet", Type = "E-Wallet", IsActive = true },
                    new PaymentMethod { Name = "Debit Card", Type = "Card", IsActive = true },
                };
                context.PaymentMethods.AddRange(paymentMethods);
            }

            if (!context.StatusUsers.Any())
            {
                var statusUsers = new List<StatusUser>
                {
                    new StatusUser { Name = "Active" },
                    new StatusUser { Name = "Inactive" },
                };
                context.StatusUsers.AddRange(statusUsers);
            }

            if (!context.Vehicles.Any())
            {
                var vehicles = new List<Vehicle>
                {
                    new Vehicle { LicensePlate = "B 1234 ABC", Type = true }, // Car
                    new Vehicle { LicensePlate = "B 5678 DEF", Type = false }, // Motorcycle
                    new Vehicle { LicensePlate = "B 9012 GHI", Type = true }, // Car
                };
                context.Vehicles.AddRange(vehicles);
            }

            context.SaveChanges();
        }
    }
}