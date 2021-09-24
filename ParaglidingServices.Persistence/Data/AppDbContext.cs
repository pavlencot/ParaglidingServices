using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Entities;
using ParaglidingServices.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Persistence.Configurations;

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


            modelBuilder.Entity<Gender>()
                //.Ignore(dl => dl.Id)
                .HasData(Enum.GetValues(typeof(GenderId))
                .Cast<GenderId>()
                .Select(dl => new Gender
                    {
                        Id = (long)dl,
                        Name = dl.ToString()
                    })
                );

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
