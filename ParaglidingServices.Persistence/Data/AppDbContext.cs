using System;
using ParaglidingServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ParaglidingServices.Persistence.Data
{
    public class AppDbContext : DbContext
    {
       

        public AppDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingLocation> BookingLocations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionOrganizer> CompetitionOrganizers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<FlightSchedule> FlightSchedules { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<PilotInstructor> PilotInstructors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            /*
                        modelBuilder.Entity<Coupon>()
                            .HasData(
                            new Coupon { Code = Guid.NewGuid(), IsApplied = false, ValidUntil = new DateTime(2022, 1, 1, 0, 0, 0) },
                            new Coupon { Code = Guid.NewGuid(), IsApplied = false, ValidUntil = new DateTime(2022, 2, 1, 0, 0, 0) },
                            new Coupon { Code = Guid.NewGuid(), IsApplied = false, ValidUntil = new DateTime(2022, 3, 1, 0, 0, 0) }


                            );*/
        }

    }
}
