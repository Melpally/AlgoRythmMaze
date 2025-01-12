using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Data.Configurations
{
    public class LevelConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
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
