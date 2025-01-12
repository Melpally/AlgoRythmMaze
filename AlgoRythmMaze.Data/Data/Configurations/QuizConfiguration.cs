using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Data.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<CaregiverProfile>
    {
        public void Configure(EntityTypeBuilder<CaregiverProfile> builder)
        {
            builder
                .HasOne(x => x.Topic)
                .WithMany(x => x.Quizzes)
                .HasForeignKey(x => x.TopicId);
        }
    }
}
