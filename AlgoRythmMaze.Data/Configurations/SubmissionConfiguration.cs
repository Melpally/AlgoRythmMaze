using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Configurations
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder
                .Property(x => x.SubmittedCode)
                .HasMaxLength(2000);

            builder
                .Property(x => x.TimeSubmitted)
                .HasDefaultValueSql("GETDATE()")
                .HasPrecision(0);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Submissions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Challenge)
                .WithMany(x => x.Submissions)
                .HasForeignKey(x => x.ChallengeId);
        }
    }
}
