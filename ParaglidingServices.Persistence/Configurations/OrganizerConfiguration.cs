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
    public class OrganizerConfiguration : BaseEntityTypeConfiguration<Organizer>
    {
        public override void Configure(EntityTypeBuilder<Organizer> builder)
        {
            builder.Property(o => o.OrganizationCode)
                .IsRequired();

            builder.HasIndex(o => o.OrganizationCode)
                .IsUnique();

            builder.Property(o => o.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(o => o.Name)
                .IsUnique();

            builder.Property(o => o.Adress)
                .IsRequired();

            builder.Property(o => o.PhoneNumber)
                .IsRequired();

            builder.Property(o => o.Description)
                .HasMaxLength(500)
                .IsRequired();


            builder.HasOne(o => o.User)
                .WithOne(u => u.Organizer)
                .HasForeignKey<Organizer>(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
