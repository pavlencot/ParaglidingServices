using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingServices.Domain.Entities;
using System;

namespace ParaglidingServices.Persistence.Configurations
{
    public class ClientConfiguration : BaseEntityTypeConfiguration<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.PhoneNumber)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
