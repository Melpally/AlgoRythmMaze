using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .Property(project => project.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .HasMany(x => x.Topics)
                .WithMany(x => x.Projects)
                .UsingEntity<ProjectTopicXP>();
        }
    }
}