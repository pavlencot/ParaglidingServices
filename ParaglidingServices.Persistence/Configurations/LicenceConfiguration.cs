using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingServices.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Persistence.Configurations
{
    public class LicenceConfiguration : BaseEntityTypeConfiguration<Licence>
    {
        public override void Configure(EntityTypeBuilder<Licence> builder)
        {
            builder.Property(l => l.LicenceNr)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(l => l.Category)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(l => l.IssuedOn)
                .IsRequired();

            builder.Property(l => l.ValidUntil)
                .IsRequired();

            builder.HasOne(l => l.Pilot)
                .WithOne(p => p.Licence)
                .HasForeignKey<Licence>(p => p.PilotId);
        }
    }
}
