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
    public class CompetitionConfiguration : BaseEntityTypeConfiguration<Competition>
    {
        public override void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.Property(c => c.CompetitionCode)
                .IsRequired();
        }
    }
}
