using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingServices.Domain.Entities;


namespace ParaglidingServices.Persistence.Configurations
{
    public class PilotInstructorConfiguration : IEntityTypeConfiguration<PilotInstructor>
    {
        public void Configure(EntityTypeBuilder<PilotInstructor> builder)
        {
            
        }
    }
}
