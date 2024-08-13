using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Data.Configurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder
                .Property(challenge => challenge.Description)
                .IsRequired();

            builder
                .Property(challenge => challenge.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .HasMany(x => x.TestCases)
                .WithOne(x => x.Challenge)
                .HasForeignKey(x => x.ChallengeId);

            builder
                .HasMany(x => x.Topics)
                .WithMany(x => x.Challenges)
                .UsingEntity<ChallengeTopicXP>();

            builder
                .HasMany(x => x.Courses)
                .WithMany(x => x.Challenges)
                .UsingEntity<CourseChallenge>();
        }
    }
}