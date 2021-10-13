using System;
using ParaglidingServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ParaglidingServices.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ParaglidingServices.Persistence.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        private const string AuthSchema = "Auth";

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingLocation> BookingLocations { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionOrganizer> CompetitionOrganizers { get; set; }
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
            
            ApplyIdentityMapConfiguration(modelBuilder);
        }

        private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", AuthSchema);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", AuthSchema);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", AuthSchema);
            modelBuilder.Entity<UserToken>().ToTable("UserRoles", AuthSchema);
            modelBuilder.Entity<Role>().ToTable("Roles", AuthSchema);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", AuthSchema);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", AuthSchema);
        }
    }
}
