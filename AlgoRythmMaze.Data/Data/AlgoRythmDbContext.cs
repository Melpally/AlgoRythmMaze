using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlgoRythmMaze.Infrastructure.Data
{
    public class AlgoRythmDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AlgoRythmDbContext(DbContextOptions<AlgoRythmDbContext> options) : base(options) { }

        public AlgoRythmDbContext() { }

        public DbSet<Hint> Hints { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TopicXP> TopicXPs { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<InterestUser> InterestUsers { get; set; }
        public DbSet<ProjectTopicXP> ProjectTopics { get; set; }
        public DbSet<BadgeUserProfile> BadgesUserProfiles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyMarker).Assembly);

        }
    }
}
