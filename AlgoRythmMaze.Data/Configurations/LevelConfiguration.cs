using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Configurations
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder
                .Property(x => x.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder
                .HasMany(x => x.UserProfiles)
                .WithOne(x => x.Level)
                .HasForeignKey(x => x.LevelId);

            builder
                .HasMany(x => x.Quizzes)
                .WithOne(x => x.Level)
                .HasForeignKey(x => x.LevelId);
        }
    }
}
