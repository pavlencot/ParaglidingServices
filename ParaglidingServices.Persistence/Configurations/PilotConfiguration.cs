using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingServices.Domain.Entities;
using System;

namespace ParaglidingServices.Persistence.Configurations
{
    public class PilotConfiguration : BaseEntityTypeConfiguration<Pilot>
    {
        public override void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.HasOne(l => l.Location)
                .WithMany(p => p.Pilots)
                .HasForeignKey(l => l.LocationId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(l => l.Licence)
                .WithOne(p => p.Pilot);

            builder.HasOne(p => p.User)
                .WithOne(u => u.Pilot);

            builder.HasOne(p => p.User)
                .WithOne(u => u.Pilot)
                .HasForeignKey<Pilot>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
