using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingServices.Domain.Entities;


namespace ParaglidingServices.Persistence.Configurations
{
    public class LocationConfiguration : BaseEntityTypeConfiguration<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasMany(c => c.Competitions)
                .WithOne(l => l.Location)
                .HasForeignKey(l => l.LocationId);
        }
    }
}
