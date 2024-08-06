using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder
                .HasKey(x => x.UserId);

            builder
                .HasMany(x => x.LearningMaterials)
                .WithMany(x => x.UserProfiles)
                .UsingEntity<LearningMaterialUser>();

            builder
                .Property(x => x.IsLevelDetermined)
                .HasDefaultValue(false);

            builder
                .Property(x => x.IsPremiumSubscriber)
                .HasDefaultValue(false);

            builder
                .HasMany(x => x.Interests)
                .WithMany(x => x.Users)
                .UsingEntity<InterestUser>();

            builder
                .HasMany(x => x.Badges)
                .WithMany(x => x.Users)
                .UsingEntity<BadgeUserProfile>();

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Profile)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Topics)
                .WithMany(x => x.UserProfiles)
                .UsingEntity<TopicXP>();
        }
    }
}
