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
    public class BookingConfiguration : BaseEntityTypeConfiguration<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.PhoneNumber)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.Date)
                .IsRequired();

            builder.HasOne(b => b.BookingLocation)
                .WithMany(b => b.Bookings)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(b => b.BookingLocationId);
        }
    }
}
