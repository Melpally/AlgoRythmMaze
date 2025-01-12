using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Data.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder
                .HasKey(x => x.UserId);

            builder
                .HasMany(x => x.Interests)
                .WithMany(x => x.UserProfiles)
                .UsingEntity<InterestUser>();

            builder
                .HasMany(x => x.Badges)
                .WithMany(x => x.Users)
                .UsingEntity<BadgeUserProfile>();

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Profile);

            builder
                .HasMany(x => x.Topics)
                .WithMany(x => x.UserProfiles)
                .UsingEntity<TopicXP>();

            builder
                .HasMany(x => x.Courses)
                .WithMany(x => x.UserProfiles)
                .UsingEntity<CourseUser>();
        }
    }
}
