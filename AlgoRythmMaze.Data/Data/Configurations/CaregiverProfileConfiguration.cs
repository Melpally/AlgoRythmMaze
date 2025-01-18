using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Data.Configurations
{
    public class CaregiverProfileConfiguration : IEntityTypeConfiguration<CaregiverProfile>
    {
        public void Configure(EntityTypeBuilder<CaregiverProfile> builder)
        {
            builder
                .HasOne(c => c.User)
                .WithOne(c => c.CaregiverProfile)
                .HasForeignKey<CaregiverProfile>(c => c.Id);

            builder
                .HasMany(c => c.Services)
                .WithMany(c => c.Caregivers)
                .UsingEntity("CaregiverService");

            builder
                .HasMany(c => c.Skills)
                .WithMany(c => c.Profiles)
                .UsingEntity("CaregiverSkill");

            builder
                .HasMany(c => c.Languages)
                .WithMany(c => c.Caregivers)
                .UsingEntity("CaregiverLanguage");
        }
    }
}
