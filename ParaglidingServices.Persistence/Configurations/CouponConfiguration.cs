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
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.Property(c => c.Code)
                .IsRequired();

            builder.Property(c => c.IsApplied)
                .HasDefaultValue(false);

            builder.Property(c => c.ValidUntil)
                .IsRequired();

            builder.HasOne(b => b.Booking)
                .WithOne(c => c.Coupon)
                .HasForeignKey<Booking>(c => c.CouponId);
        }
    }
}
