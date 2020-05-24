using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using TripTracker.BackService.Models;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace TripTracker.BackService.Data
{
    public class TripContext : DbContext
    {
        public TripContext() { }

        public TripContext(DbContextOptions<TripContext> options) : base(options) { }

        public DbSet<Trip> Trips { get; set; }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated();
                
                if (context.Trips.Any()) return;
                
                context.Trips.AddRange(new Trip[]
                    {
                         new Trip
                        {
                            Id = 1,
                            Name = "India",
                            StartDarte = new DateTime(2020,03,12),
                            EndDate = new DateTime(2020, 03, 20)
                        },
                        new Trip
                        {
                            Id = 2,
                            Name = "Sydney",
                            StartDarte = new DateTime(2020,06,15),
                            EndDate = new DateTime(2020, 06, 20)
                        },
                        new Trip
                        {
                            Id = 3,
                            Name = "Melbourne",
                            StartDarte = new DateTime(2020,07,03),
                            EndDate = new DateTime(2020, 07, 05)
                        }
                    }
                );

                context.SaveChanges();
            }

        }

    }
}
