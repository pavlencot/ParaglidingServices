using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Persistence.Configurations
{
    public class PilotConfiguration : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.HasOne(l => l.Location)
                .WithMany(p => p.Pilots)
                .HasForeignKey(l => l.LocationId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasKey(p => p.Id);

            builder.HasOne(l => l.Licence)
                .WithOne(p => p.Pilot)
                .HasForeignKey<Licence>(p => p.PilotId);
        }
    }
}
