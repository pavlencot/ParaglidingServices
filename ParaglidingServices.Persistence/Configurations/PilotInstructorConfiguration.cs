using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingServices.Domain.Entities;


namespace ParaglidingServices.Persistence.Configurations
{
    public class PilotInstructorConfiguration : BaseEntityTypeConfiguration<PilotInstructor>
    {
        public override void Configure(EntityTypeBuilder<PilotInstructor> builder)
        {
        }
    }
}
