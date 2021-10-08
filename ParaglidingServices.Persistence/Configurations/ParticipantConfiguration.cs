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
    public class ParticipantConfiguration : BaseEntityTypeConfiguration<Participant>
    {
        public override void Configure(EntityTypeBuilder<Participant> builder)
        {
            //builder.HasOne(p => p.Pilot)
            //    .WithMany(p => p.Participants)
            //    .HasForeignKey(p => p.PilotId);

            builder.HasOne(c => c.Competition)
                .WithMany(p => p.Participants)
                .HasForeignKey(c => c.CompetitionId);
        }
    }
}
