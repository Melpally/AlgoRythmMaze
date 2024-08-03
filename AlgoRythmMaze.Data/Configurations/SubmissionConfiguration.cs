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
                .Property(comment => comment.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder
                .Property(submission => submission.SubmittedCode)
                .HasMaxLength(2000);

            builder
                .Property(comment => comment.TimeSubmitted)
                .HasDefaultValueSql("GETDATE()")
                .HasPrecision(0);

            //user + challenge
            builder
                .HasMany(x => x)
                .WithOne(x => x.ThreadStartingComment)
                .HasForeignKey(x => x.ThreadCommentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
