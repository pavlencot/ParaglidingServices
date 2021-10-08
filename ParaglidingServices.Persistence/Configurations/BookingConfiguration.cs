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
            builder.Property(b => b.Date)
                .IsRequired();

            builder.HasOne(c => c.Client)
                .WithMany(b => b.Bookings)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(b => b.ClientId);

            builder.HasOne(b => b.BookingLocation)
                .WithMany(b => b.Bookings)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(b => b.BookingLocationId);

            builder.HasOne(i => i.Instructor)
                .WithMany(b => b.Bookings)
                .HasForeignKey(i => i.InstructorId);

        }
    }
}
