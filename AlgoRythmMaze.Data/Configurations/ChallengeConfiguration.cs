using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Configurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder
                .Property(challenge => challenge.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder
                .Property(challenge => challenge.Description)
                .HasMaxLength(2000)
                .IsRequired();

            builder
                .Property(challenge => challenge.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .HasMany(x => x.TestCases)
                .WithOne(x => x.Challenge)
                .HasForeignKey(x => x.ChallengeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}